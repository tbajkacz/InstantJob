import React, { useEffect, useState } from "react";
import LoadingIndicator from "../../Common/LoadingIndicator";
import JobListItem from "./JobListItem";
import { JobOverview } from "./jobsTypes";
import { jobsService } from "./jobsService";
import TopFilterPanel from "./TopFilterPanel";
import { useQueryParams } from "../../Common/buildQuery";
import { useLocation } from "react-router";

interface JobsListProps {
  className?: string;
}

export interface JobsListQuery {
  search: string;
  categoryId: string;
}

export default function JobsList(props: JobsListProps) {
  const [loadingPromise, setLoadingPromise] = useState<Promise<any>>();

  const [jobsList, setJobsList] = useState<JobOverview[]>();

  const queryParams = useQueryParams<JobsListQuery>();

  const location = useLocation();

  const onFiltersChanged = () => {
    //updateJobs();
  };

  const formatTitle = () => {
    if (jobsList && jobsList.length > 0) {
      return `Found ${jobsList.length} available job ${jobsList.length > 1 ? "offers" : "offer"}`;
    }
    return "No available job offers found";
  };

  const updateJobs = () => {
    console.log(queryParams);
    setLoadingPromise(
      jobsService.GetJobs(queryParams ? { categoryId: queryParams.categoryId } : {}).then((r) => {
        setJobsList(r.data);
      })
    );
  };

  useEffect(updateJobs, [location.search]);

  return (
    <div className={props.className}>
      <LoadingIndicator promise={loadingPromise}>
        <div className={props.className}>
          {jobsList ? (
            <div className="ui-list-flex-container">
              <div className="ui-list-wrapper col-sm-9">
                <TopFilterPanel className="ui-list-header" filtersChanged={onFiltersChanged} />
                <small className="text-white">TODO Sortowanie</small>
                <h3 className="ui-list-header">{formatTitle()}</h3>
                <ul className="ui-list-dark">
                  {jobsList.map((c) => (
                    <JobListItem key={c.id} job={c} />
                  ))}
                </ul>
              </div>
            </div>
          ) : null}
        </div>
      </LoadingIndicator>
    </div>
  );
}
