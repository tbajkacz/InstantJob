import React, { useEffect, useState } from "react";
import { useHistory, useParams } from "react-router";
import LoadingIndicator from "../../Common/LoadingIndicator";
import { jobsService } from "./jobsService";
import { JobDetails } from "./jobsTypes";
import { combineClasses } from "./../../Common/componentUtility";
import { useAuth } from "../../Common/Auth/authContext";
import { Button } from "reactstrap";
import routes, { routeParams } from "../../Common/routes";
import { formatDate, getFormattedTimeLeft } from "./../../Common/dateFormatter";
import JobsFilterBadgePill from "./JobsFilterBadgePill";
import { JobsListQuery } from "./JobsList";
import { buildQuery } from "../../Common/buildQuery";
import roles from "./../../Common/roles";
import UserProfileAnchor from "./../../Common/UserProfileAnchor";

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
  const [hasActiveApplication, setHasActiveApplication] = useState<boolean>();

  const [entityHasUpdatedToggle, setEntityHasUpdatedToggle] = useState<boolean>();

  const auth = useAuth();
  const history = useHistory();

  useEffect(() => {
    setLoadingPromise(refreshJobDetails());
  }, []);

  useEffect(() => {
    if (jobDetails && auth.currentUser?.role.name === roles.contractor) {
      jobsService.HasActiveApplication({ jobId: jobDetails.id }).then((r) => {
        setHasActiveApplication(r.data.hasActiveApplication);
      });
    }
  }, [jobDetails]);

  useEffect(() => {
    refreshJobDetails();
  }, [entityHasUpdatedToggle]);

  const refreshJobDetails = () => {
    return jobsService.GetJobDetails({ jobId }).then((r) => {
      setJobDetails(r.data);
    });
  };

  const applyForJob = () => {
    if (auth.currentUser && auth.currentUser.role.name === roles.contractor && jobDetails) {
      jobsService.ApplyForJob({ jobId: jobDetails.id }).then(() => setEntityHasUpdatedToggle(!entityHasUpdatedToggle));
    }
  };

  const withdrawJobApplication = () => {
    if (auth.currentUser && auth.currentUser.role.name === roles.contractor && jobDetails) {
      jobsService
        .WithdrawJobApplication({ jobId: jobDetails.id })
        .then(() => setEntityHasUpdatedToggle(!entityHasUpdatedToggle));
    }
  };

  const acceptAssignment = () => {
    if (auth.currentUser && auth.currentUser.role.name === roles.contractor && jobDetails) {
      jobsService
        .AcceptJobAssignment({ jobId: jobDetails.id })
        .then(() => setEntityHasUpdatedToggle(!entityHasUpdatedToggle));
    }
  };

  const redirectToBrowseApplications = () => {
    if (jobDetails) {
      history.push(routes.Applications.replace(routeParams.jobId, jobDetails.id));
    }
  };

  if (!jobDetails) {
    return <div>Invalid job details</div>;
  }

  const renderContractorUnassignedApplicationsSection = () => {
    return (
      <Button
        color="primary"
        className="btn-block mt-1"
        onClick={!hasActiveApplication ? applyForJob : withdrawJobApplication}
      >
        {!hasActiveApplication ? "Apply" : "Withdraw application"}
      </Button>
    );
  };

  const renderContractorAssignedApplicationsSection = () => {
    if (
      auth.currentUser &&
      auth.currentUser.role.name === roles.contractor &&
      auth.currentUser.id === jobDetails.contractor.id
    ) {
      return (
        <Button color="primary" className="btn-block mt-1" onClick={acceptAssignment}>
          Begin job
        </Button>
      );
    }

    return "This job is already assigned to another contractor";
  };

  const renderMandatorNotInProgressApplicationsSection = () => {
    return (
      <Button color="primary" className="btn-block mt-1" onClick={redirectToBrowseApplications}>
        Browse applications
      </Button>
    );
  };

  const renderApplicationsCountSection = () => {
    return `${jobDetails.applications.length} ${
      jobDetails.applications.length === 1 ? "application" : "applications"
    } for this job`;
  };

  const renderCompletionInfo = () => {
    return (
      <>
        Completed on {formatDate(jobDetails.completionInfo.completionDate)} by {jobDetails.contractor.name}{" "}
        {jobDetails.contractor.surname}
      </>
    );
  };

  const renderApplicationSection = () => {
    if (jobDetails.status.isCompleted) {
      return renderCompletionInfo();
    } else if (jobDetails.status.isInProgress) {
      return "This job is already in progress";
    } else if (jobDetails.status.isCanceled) {
      return "This job offer was canceled";
    } else if (jobDetails.status.isAssigned) {
      if (auth.currentUser?.role?.name === roles.mandator) {
        return renderMandatorNotInProgressApplicationsSection();
      } else if (auth.currentUser?.role?.name === roles.contractor) {
        return renderContractorAssignedApplicationsSection();
      }
    } else {
      if (auth.currentUser?.role?.name === roles.mandator) {
        return renderMandatorNotInProgressApplicationsSection();
      } else if (auth.currentUser?.role?.name === roles.contractor) {
        return renderContractorUnassignedApplicationsSection();
      }
      return null;
    }
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
            <div className="col-sm-2">
              <h5>{`Offered price: ${jobDetails.price ? `$${jobDetails.price}` : "not specified"}`}</h5>
              <div>{renderApplicationsCountSection()}</div>
              <h6 className="mt-2">{renderTimeLeft()}</h6>
              {renderApplicationSection()}
            </div>
          </div>
          <div className="ui-content">
            <div className="col-sm-12">
              <h6>
                Posted by <UserProfileAnchor user={jobDetails.mandator} /> at {formatDate(jobDetails.postedDate)}
              </h6>
            </div>
          </div>
        </div>
      </div>
    </LoadingIndicator>
  );
}
