import React from "react";
import { useHistory } from "react-router";
import { buildQuery } from "../../Common/buildQuery";
import { combineClasses } from "../../Common/componentUtility";
import routes from "../../Common/routes";
import { JobsListQuery } from "./JobsList";
import { JobOverview } from "./jobsTypes";

interface JobsListItemProps {
  job: JobOverview;
}

export default React.memo(function JobListItem(props: JobsListItemProps) {
  let itemClass = false ? "ui-list-item-dark ui-selected" : "ui-list-item-dark";

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

  const postedDate = new Date(props.job.postedDate);

  let query: JobsListQuery = {
    categoryId: props.job.category.id,
    search: "",
  };

  const categoryFilterRoute = `${routes.Jobs}${buildQuery(query)}`;

  const onCategoryAnchorClick = (e: React.MouseEvent<HTMLAnchorElement>) => {
    e.preventDefault();
    e.stopPropagation();
    history.push(categoryFilterRoute);
  };

  return (
    <li className={combineClasses(itemClass, "row")} onClick={redirectToJob}>
      <div className="col-sm-9">
        <div className="h5">{props.job.title}</div>
        <div>{renderDescription()}</div>
        <small>
          <a href={categoryFilterRoute} onClick={onCategoryAnchorClick}>
            {props.job.category.name}
          </a>
        </small>
      </div>
      <div className="col-sm-3">
        <div>{renderPrice()}</div>
        <small className="ui-position-bottom">
          {`${postedDate.toLocaleDateString("pl-PL")} ${postedDate.toLocaleTimeString("pl-PL")} by `}
          <a
            href={`${routes.Profile}/${props.job.mandator.id}`}
          >{`${props.job.mandator.name} ${props.job.mandator.surname}`}</a>
        </small>
      </div>
    </li>
  );
});
