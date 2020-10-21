import React from "react";
import { Button } from "reactstrap";
import { formatDate } from "../../Common/dateFormatter";
import UserProfileAnchor from "../../Common/UserProfileAnchor";
import { jobsService } from "./jobsService";
import { Contractor, JobApplication, JobStatus } from "./jobsTypes";

interface JobApplicationsListItemProps {
  application: JobApplication;
  jobId: string;
  assignedContractor: Contractor | undefined;
  status: JobStatus;
  onAction: () => void;
}

export default function JobApplicationsListItem(props: JobApplicationsListItemProps) {
  const assignContractor = () => {
    jobsService
      .AssignContractor({ jobId: props.jobId, contractorId: props.application.contractor.id })
      .then(props.onAction);
  };

  const cancelAssignment = () => {
    jobsService.CancelAssignment({ jobId: props.jobId }).then(props.onAction);
  };

  const renderActionButton = () => {
    if (!props.status.isAssigned && !props.status.isInProgress) {
      return (
        <Button color="primary" className="btn-block" onClick={assignContractor}>
          Assign
        </Button>
      );
    } else if (
      props.status.isAssigned &&
      props.assignedContractor &&
      props.application.contractor.id === props.assignedContractor.id
    ) {
      return (
        <Button color="primary" className="btn-block" onClick={cancelAssignment}>
          Unassign
        </Button>
      );
    }
    return "";
  };

  return (
    <li className="row ui-list-item-dark">
      <div className="col-sm-10">
        <div>
          {"Contractor "} <UserProfileAnchor user={props.application.contractor} />
          {" applied at "}
          {`${formatDate(props.application.applicationDate)}`}
        </div>
      </div>

      <div className="col-sm-2">{renderActionButton()}</div>
    </li>
  );
}
