import React from "react";
import { useHistory } from "react-router";

export interface JobsFilterBadgePillProps {
  children: string;
  href: string;
}

export default function JobsFilterBadgePill(props: JobsFilterBadgePillProps) {
  const history = useHistory();

  const onCategoryAnchorClick = (e: React.MouseEvent<HTMLAnchorElement>) => {
    e.preventDefault();
    e.stopPropagation();
    history.push(props.href);
  };

  return (
    <small>
      <a className="ui-anchor-pill" href={props.href} onClick={onCategoryAnchorClick}>
        {props.children}
      </a>
    </small>
  );
}
