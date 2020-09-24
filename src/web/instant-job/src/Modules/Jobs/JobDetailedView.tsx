import React, { useEffect, useState } from "react";
import { useParams } from "react-router";
import LoadingIndicator from "../../Common/LoadingIndicator";
import { jobsService } from "./jobsService";
import { JobDetails } from "./jobsTypes";
import { combineClasses } from "./../../Common/componentUtility";
import { useAuth } from "../../Common/Auth/authContext";
import roles from "../../Common/roles";
import { Button } from "reactstrap";
import routes from "../../Common/routes";
import { formatDate, getFormattedTimeLeft } from "./../../Common/dateFormatter";
import JobsFilterBadgePill from "./JobsFilterBadgePill";
import { JobsListQuery } from "./JobsList";
import { buildQuery } from "../../Common/buildQuery";

export interface JobDetailedViewProps {
  className?: string;
}

export interface JobDetailedViewRouteProps {
  jobId: string;
}

export interface JobsDetailedViewQuery {
  categoryId: string;
  difficultyId: number;
}

export default function JobDetailedView(props: JobDetailedViewProps) {
  const { jobId } = useParams<JobDetailedViewRouteProps>();

  const [jobDetails, setJobDetails] = useState<JobDetails>();
  const [loadingPromise, setLoadingPromise] = useState<Promise<any>>();

  const auth = useAuth();

  useEffect(() => {
    setLoadingPromise(
      jobsService.GetJobDetails({ jobId }).then((r) => {
        setJobDetails(r.data);
      })
    );
  }, []);

  if (!jobDetails) {
    return <div>Invalid job details</div>;
  }

  const renderApplicationsSection = () => {
    let content: JSX.Element | string;
    if (jobDetails.isCompleted) {
      content = "This job has already been completed";
    } else if (jobDetails.isInProgress) {
      content = "This job is already in progres";
    } else if (jobDetails.wasCanceled) {
      content = "This job offer was canceled";
    } else {
      content = (
        <>
          <h5>{`Offered price: ${jobDetails.price ? `$${jobDetails.price}` : "not specified"}`}</h5>
          <div>{jobDetails.applications.length} applications for this job</div>
          <h6 className="mt-2">{renderTimeLeft()}</h6>
          {auth.currentUser?.role?.name?.toLowerCase() === roles.contractor ? (
            <Button className="btn-block mt-1">Apply</Button>
          ) : null}
        </>
      );
    }

    return content;
  };

  const renderTimeLeft = () => {
    let timeLeft = getFormattedTimeLeft(jobDetails.deadline);
    let timeTypeText = timeLeft.count === 1 ? timeLeft.type.substring(0, timeLeft.type.length - 1) : timeLeft.type;

    return `${timeLeft.count} ${timeTypeText} left`;
  };

  return (
    <LoadingIndicator promise={loadingPromise}>
      <div className={combineClasses(props.className, "ui-flex-container")}>
        <div className="ui-wrapper col-sm-9">
          <div className="ui-header">
            <h2>{jobDetails.title}</h2>
          </div>
          <div className="ui-content">
            <div className="col-sm-10">
              <p>{jobDetails.description}</p>
              <JobsFilterBadgePill href={`${routes.Jobs}${buildQuery({ categoryId: jobDetails.category.id })}`}>
                {jobDetails.category.name}
              </JobsFilterBadgePill>
              <JobsFilterBadgePill href={`${routes.Jobs}${buildQuery({ difficultyId: jobDetails.difficulty.id })}`}>
                {jobDetails.difficulty.name}
              </JobsFilterBadgePill>
            </div>
            <div className="col-sm-2">{renderApplicationsSection()}</div>
          </div>
          <div className="ui-content">
            <div className="col-sm-12">
              <h6>
                Posted by{" "}
                <a
                  href={`${routes.Profile}/${jobDetails.mandator.id}`}
                >{`${jobDetails.mandator.name} ${jobDetails.mandator.surname}`}</a>{" "}
                at {formatDate(jobDetails.postedDate)}
              </h6>
            </div>
          </div>
        </div>
      </div>
    </LoadingIndicator>
  );
}
