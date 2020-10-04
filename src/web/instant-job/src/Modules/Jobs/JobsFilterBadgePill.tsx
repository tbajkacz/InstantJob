import React from "react";
import { useHistory } from "react-router";

export interface JobsFilterBadgePillProps {
  children: string;
  href?: string;
}

export default function JobsFilterBadgePill(props: JobsFilterBadgePillProps) {
  const history = useHistory();

  const getHref = () => {
    if (props.href) {
      return props.href;
    }
    return history.location.pathname + history.location.search;
  };

  const onCategoryAnchorClick = (e: React.MouseEvent<HTMLAnchorElement>) => {
    e.preventDefault();
    e.stopPropagation();
    history.push(getHref());
  };

  return (
    <small>
      <a className="ui-anchor-pill" href={getHref()} onClick={onCategoryAnchorClick}>
        {props.children}
      </a>
    </small>
  );
}
