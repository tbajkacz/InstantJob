import React from "react";
import { useHistory } from "react-router";

export interface JobsFilterBadgePillProps {
  children: string;
  href?: string;
  type: "primary" | "danger" | "success";
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

  const getClassName = () => {
    switch (props.type) {
      case "danger":
        return "ui-anchor-pill-danger";
      case "primary":
        return "ui-anchor-pill";
      case "success":
        return "ui-anchor-pill-success";
    }
  };

  return (
    <small>
      <a className={getClassName()} href={getHref()} onClick={onCategoryAnchorClick}>
        {props.children}
      </a>
    </small>
  );
}
