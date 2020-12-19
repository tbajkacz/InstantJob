import React from "react";
import { Button } from "reactstrap";
import { useAuth } from "../../Common/Auth/authContext";
import { formatDate } from "../../Common/dateFormatter";
import UserProfileAnchor from "../../Common/UserProfileAnchor";
import { jobsService } from "./jobsService";
import { Contractor, JobApplication, JobStatus } from "./jobsTypes";

interface JobApplicationsListItemProps {
  application: JobApplication;
  mandatorId: string;
  jobId: string;
  assignedContractor: Contractor | undefined;
  status: JobStatus;
  onAction: () => void;
}

export default function JobApplicationsListItem(props: JobApplicationsListItemProps) {
  const auth = useAuth();
  const assignContractor = () => {
    jobsService
      .AssignContractor({ jobId: props.jobId, contractorId: props.application.contractor.id })
      .then(props.onAction);
  };

  const cancelAssignment = () => {
    jobsService.CancelAssignment({ jobId: props.jobId }).then(props.onAction);
  };

  const renderActionButton = () => {
    if (props.mandatorId !== auth.currentUser?.id || props.status.isCompleted) {
      return "";
    }
    if (!props.status.isAssigned && !props.status.isInProgress) {
      return (
        <Button
          size="sm"
          color="primary"
          className="btn-block"
          onClick={assignContractor}
          disabled={props.mandatorId !== auth.currentUser?.id}
        >
          Assign
        </Button>
      );
    } else if (
      props.status.isAssigned &&
      props.assignedContractor &&
      props.application.contractor.id === props.assignedContractor.id
    ) {
      return (
        <Button
          size="sm"
          color="primary"
          className="btn-block"
          onClick={cancelAssignment}
          disabled={props.mandatorId !== auth.currentUser?.id}
        >
          Unassign
        </Button>
      );
    }
    return "";
  };

  return (
    <tr className="">
      <td>
        <UserProfileAnchor user={props.application.contractor} />
      </td>
      <td>{formatDate(props.application.applicationDate)}</td>
      <td>{renderActionButton()}</td>
    </tr>
  );
}
