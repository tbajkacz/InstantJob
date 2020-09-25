import React from "react";
import { Button } from "reactstrap";
import { formatDate } from "../../Common/dateFormatter";
import UserProfileAnchor from "../../Common/UserProfileAnchor";
import { jobsService } from "./jobsService";
import { Contractor, JobApplication } from "./jobsTypes";

interface ApplicationsListItemProps {
  application: JobApplication;
  jobId: string;
  assignedContractor: Contractor | undefined;
  isUnassigned: boolean;
  isInProgress: boolean;
  onAction: () => void;
}

export default function ApplicationsListItem(props: ApplicationsListItemProps) {
  const assignContractor = () => {
    jobsService
      .AssignContractor({ jobId: props.jobId, contractorId: props.application.contractor.id })
      .then(props.onAction);
  };

  const cancelAssignment = () => {
    jobsService.CancelAssignment({ jobId: props.jobId }).then(props.onAction);
  };

  return (
    <li className="row ui-list-item-dark">
      <div className="col-sm-10">
        <div>
          TODO Picture, age, completed jobs etc ||
          {"Contractor "} <UserProfileAnchor user={props.application.contractor} />
          {" applied at "}
          {`${formatDate(props.application.applicationDate)}`}
        </div>
      </div>

      <div className="col-sm-2">
        {props.isUnassigned ? (
          <Button color="primary" className="btn-block" onClick={assignContractor}>
            Assign
          </Button>
        ) : props.assignedContractor &&
          !props.isInProgress &&
          props.application.contractor.id === props.assignedContractor.id ? (
          <Button color="primary" className="btn-block" onClick={cancelAssignment}>
            Unassign
          </Button>
        ) : null}
      </div>
    </li>
  );
}
