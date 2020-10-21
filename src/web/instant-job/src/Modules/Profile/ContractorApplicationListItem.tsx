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
    <li className="row ui-list-item-dark-interactive" onClick={onClick}>
      <div className="col-sm-10">
        <div>{`${props.application.jobTitle}`}</div>
        <div>{`${formatDate(props.application.applicationDate)}`}</div>
      </div>
    </li>
  );
}
