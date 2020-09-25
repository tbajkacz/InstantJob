import React from "react";
import { useHistory } from "react-router";
import { Mandator } from "../Modules/Jobs/jobsTypes";
import { Contractor } from "./../Modules/Jobs/jobsTypes";
import routes, { routeParams } from "./routes";

interface UserProfileAnchorProps {
  user: Mandator | Contractor;
}

export default function UserProfileAnchor(props: UserProfileAnchorProps) {
  const history = useHistory();

  const href = `${routes.Profile.replace(routeParams.userId, props.user.id)}`;

  const onAnchorClick = (e: React.MouseEvent<HTMLAnchorElement, MouseEvent>) => {
    e.preventDefault();
    e.stopPropagation();

    history.push(href);
  };

  return <a className="ui-anchor" href={href} onClick={onAnchorClick}>{`${props.user.name} ${props.user.surname}`}</a>;
}
