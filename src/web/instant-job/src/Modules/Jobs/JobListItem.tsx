import React from "react";
import { useHistory } from "react-router";
import { buildQuery } from "../../Common/buildQuery";
import { combineClasses } from "../../Common/componentUtility";
import routes from "../../Common/routes";
import { JobOverview } from "./jobsTypes";
import { formatDate } from "./../../Common/dateFormatter";
import JobsFilterBadgePill from "./JobsFilterBadgePill";
import UserProfileAnchor from "../../Common/UserProfileAnchor";

interface JobsListItemProps {
  job: JobOverview;
}

interface JobsListItemQuery {
  categoryId: string;
  difficultyId: number;
}

export default React.memo(function JobListItem(props: JobsListItemProps) {
  const history = useHistory();

  const redirectToJob = () => history.push(`${routes.Jobs}/${props.job.id}`);

  const renderPrice = () => {
    return `Offered price: ${props.job.price ? `$${props.job.price}` : "not specified"}`;
  };

  const renderDescription = () => {
    if (props.job.description.length > 300) {
      return props.job.description.substring(0, 300) + "...";
    }
    return props.job.description;
  };

  const formatJobStatus = () => {
    return props.job.status.name.replace(/([A-Z])/g, " $1").trim();
  };

  const renderStatusInfo = () => {
    if (props.job.status.isAvailable) {
      return `${props.job.applicationsCount} applications`;
    }
  };

  const postedDate = new Date(props.job.postedDate);

  return (
    <li className={combineClasses("ui-list-item-dark-interactive", "row")} onClick={redirectToJob}>
      <div className="col-sm-9">
        <div className="h5">{props.job.title}</div>
        <div>{renderDescription()}</div>
        <JobsFilterBadgePill href={`${routes.Jobs}${buildQuery({ categoryId: props.job.category.id })}`}>
          {props.job.category.name}
        </JobsFilterBadgePill>
        <JobsFilterBadgePill href={`${routes.Jobs}${buildQuery({ difficultyId: props.job.difficulty.id })}`}>
          {props.job.difficulty.name}
        </JobsFilterBadgePill>
        <JobsFilterBadgePill>{formatJobStatus()}</JobsFilterBadgePill>
      </div>
      <div className="col-sm-3">
        <div>{renderPrice()}</div>
        <div>{renderStatusInfo()}</div>
        <small className="ui-position-bottom">
          {`${formatDate(postedDate)} by `}
          <UserProfileAnchor user={props.job.mandator} />
        </small>
      </div>
    </li>
  );
});
