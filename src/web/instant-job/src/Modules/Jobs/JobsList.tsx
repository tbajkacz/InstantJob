import React, { useEffect, useState } from "react";
import LoadingIndicator from "../../Common/LoadingIndicator";
import JobListItem from "./JobListItem";
import { JobOverview, jobStatusName } from "./jobsTypes";
import { jobsService } from "./jobsService";
import TopFilterPanel from "./TopFilterPanel";
import { useQueryParams } from "../../Common/buildQuery";
import { useHistory, useLocation } from "react-router";
import { userService } from "../Profile/userService";
import JobModal from "./JobModal";
import { Link } from "react-router-dom";
import routes from "../../Common/routes";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faPlus } from "@fortawesome/free-solid-svg-icons";

interface JobsListProps {
  className?: string;
}

export interface JobsListQuery {
  searchString?: string;
  categoryId?: string;
  difficultyId?: number;
  status?: string;
  mandatorId?: string;
  contractorId?: string;
  includeExpired?: boolean;
}

interface JobUserInfo {
  name: string;
  surname: string;
}

export default function JobsList(props: JobsListProps) {
  const [loadingPromise, setLoadingPromise] = useState<Promise<any>>();

  const [jobsList, setJobsList] = useState<JobOverview[]>();

  const queryParams = useQueryParams<JobsListQuery>();

  const [jobUserInfo, setJobUserInfo] = useState<JobUserInfo>();

  const location = useLocation();

  const history = useHistory();
  const [isPostJobModalOpen, setIsPostJobModalOpen] = useState(false);
  const togglePostJobModal = () => {
    setIsPostJobModalOpen(!isPostJobModalOpen);
  };

  const postJobRoute = () => {
    if (location.pathname.includes(routes.Jobs)) {
      return location.pathname + location.search;
    }
    return routes.Jobs;
  };

  const updateJobs = () => {
    setLoadingPromise(
      jobsService.GetJobs(queryParams ? queryParams : {}).then((r) => {
        setJobsList(r.data);
      })
    );
  };

  useEffect(() => {
    updateJobs();
    if (queryParams?.mandatorId) {
      userService
        .getUserById({ userId: queryParams.mandatorId })
        .then((r) => setJobUserInfo({ name: r.data.name, surname: r.data.surname }));
    } else if (queryParams?.contractorId) {
      userService
        .getUserById({ userId: queryParams.contractorId })
        .then((r) => setJobUserInfo({ name: r.data.name, surname: r.data.surname }));
    }
  }, [location.search]);

  if (!jobsList) {
    return null;
  }

  const titleJobStatus = () => {
    switch (queryParams?.status) {
      case jobStatusName.Assigned:
        return "assigned to";
      case jobStatusName.InProgress:
        return "in progress by";
      case jobStatusName.Completed:
        return "completed by";
    }
  };

  const getSingularOrPluralOfferString = () => (jobsList.length > 1 ? "offers" : "offer");

  const formatTitle = () => {
    if (jobsList && jobsList.length > 0) {
      if (queryParams?.mandatorId) {
        //TODO in theory all the jobs would belong to this mandator in this case, but refactor the jobsList[0] thing anyway
        return `Found ${jobsList.length} job ${getSingularOrPluralOfferString()} posted by ${jobUserInfo?.name} ${
          jobUserInfo?.surname
        }`;
      }
      if (queryParams?.contractorId) {
        return `Found ${jobsList.length} job ${getSingularOrPluralOfferString()} ${titleJobStatus()} ${
          jobUserInfo?.name
        } ${jobUserInfo?.surname}`;
      }

      return `Found ${jobsList.length} available job ${getSingularOrPluralOfferString()}`;
    }
    return "No job offers matching the search criteria were found";
  };

  return (
    <LoadingIndicator promise={loadingPromise}>
      <div className={props.className}>
        <div className="ui-flex-container">
          <div className="ui-wrapper col-sm-9">
            <TopFilterPanel className="ui-header" />
            <div className="ui-header row">
              <h3 className="col-md-11 pr-0">{formatTitle()} </h3>
              <Link className="ui-nav-link ui-icon-button col-md-1" to={postJobRoute()} onClick={togglePostJobModal}>
                <FontAwesomeIcon icon={faPlus} size="2x" />
              </Link>
            </div>
            <ul className="ui-list-dark">
              {jobsList.map((c) => (
                <JobListItem key={c.id} job={c} />
              ))}
            </ul>
          </div>
        </div>
      </div>
      <JobModal
        type="add"
        isOpen={isPostJobModalOpen}
        toggle={togglePostJobModal}
        onSuccessClosed={(id) => history.push(`${routes.Jobs}/${id}`)}
      />
    </LoadingIndicator>
  );
}
