import React from "react";
import { useHistory } from "react-router";
import { formatDate } from "../../Common/dateFormatter";
import routes from "../../Common/routes";
import { ContractorApplication } from "./userTypes";
import { routeParams } from "./../../Common/routes";

interface ContractorApplicationListItemProps {
  application: ContractorApplication;
}

export default function ContractorApplicationListItem(props: ContractorApplicationListItemProps) {
  const history = useHistory();

  const onClick = () => {
    history.push(routes.DetailedJob.replace(routeParams.jobId, props.application.jobId));
  };
  return (
    <tr className="ui-interactive" onClick={onClick}>
      <td>{props.application.jobId}</td>
      <td>{props.application.jobTitle}</td>
      <td>{formatDate(props.application.applicationDate)}</td>
    </tr>
  );
}
