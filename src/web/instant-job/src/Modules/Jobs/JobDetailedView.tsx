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
import JobModal from "./JobModal";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faCog, faEdit } from "@fortawesome/free-solid-svg-icons";

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

  const [isEditModalOpen, setIsEditModalOpen] = useState(false);
  const toggleEditModal = () => setIsEditModalOpen(!isEditModalOpen);
  const [refresh, setRefresh] = useState(false);
  const onEditModalClosed = () => setRefresh(!refresh);

  useEffect(() => {
    setLoadingPromise(refreshJobDetails());
  }, [refresh]);

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
    if (auth.currentUser && jobDetails && auth.currentUser.id === jobDetails.contractor.id) {
      jobsService
        .AcceptJobAssignment({ jobId: jobDetails.id })
        .then(() => setEntityHasUpdatedToggle(!entityHasUpdatedToggle));
    }
  };

  const completeJob = () => {
    if (auth.currentUser && jobDetails && auth.currentUser.id === jobDetails.mandator.id) {
      jobsService.CompleteJob({ jobId: jobDetails.id }).then(() => setEntityHasUpdatedToggle(!entityHasUpdatedToggle));
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

    return (
      <>
        This job is already assigned to <UserProfileAnchor user={jobDetails.contractor} />
      </>
    );
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
    } else if (jobDetails.hasExpired) {
      return "This job offer has expired";
    } else if (jobDetails.status.isInProgress) {
      if (auth.currentUser && auth.currentUser.id === jobDetails.mandator.id) {
        return (
          <Button onClick={completeJob} color="primary">
            Mark as completed
          </Button>
        );
      }
      return (
        <>
          This job is already in progress by{" "}
          <UserProfileAnchor
            customText={auth.currentUser?.id === jobDetails.contractor.id ? "You" : ""}
            user={jobDetails.contractor}
          />
        </>
      );
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

    return timeLeft.count >= 0 ? `${timeLeft.count} ${timeTypeText} left` : "";
  };

  const titleSubstr = () => {
    if (jobDetails.title.length > 50) {
      return jobDetails.title.substring(0, 50) + "...";
    }
    return jobDetails.title;
  };

  const renderTitle = () => {
    if (auth.currentUser?.role.name === roles.mandator) {
      return (
        <div className="row">
          <h2 className="col-md-auto mr-0 pr-0">{titleSubstr()}</h2>
          <Button className="inline col-md-auto ui-icon-button" onClick={toggleEditModal}>
            <FontAwesomeIcon icon={faEdit} color="white" />
          </Button>
        </div>
      );
    }
    return titleSubstr();
  };

  return (
    <LoadingIndicator promise={loadingPromise}>
      <div className={combineClasses(props.className, "ui-flex-container")}>
        <div className="ui-wrapper col-sm-9">
          <div className="ui-header">{renderTitle()}</div>
          <div className="ui-content">
            <div className="col-sm-10">
              <p>{jobDetails.description}</p>
              <JobsFilterBadgePill
                type="primary"
                href={`${routes.Jobs}${buildQuery({ categoryId: jobDetails.category.id })}`}
              >
                {jobDetails.category.name}
              </JobsFilterBadgePill>
              <JobsFilterBadgePill
                type="primary"
                href={`${routes.Jobs}${buildQuery({ difficultyId: jobDetails.difficulty.id })}`}
              >
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
        <JobModal
          type="edit"
          jobDetails={jobDetails}
          isOpen={isEditModalOpen}
          toggle={toggleEditModal}
          onSuccessClosed={onEditModalClosed}
        />
      </div>
    </LoadingIndicator>
  );
}
