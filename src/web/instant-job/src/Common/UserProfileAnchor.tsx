import React from "react";
import { useHistory } from "react-router";
import { Mandator } from "../Modules/Jobs/jobsTypes";
import { Contractor } from "./../Modules/Jobs/jobsTypes";
import routes, { routeParams } from "./routes";

interface UserProfileAnchorProps {
  user: Mandator | Contractor;
  customText?: string;
}

export default function UserProfileAnchor(props: UserProfileAnchorProps) {
  const history = useHistory();

  const href = `${routes.Profile.replace(routeParams.userId, props.user.id)}`;

  const onAnchorClick = (e: React.MouseEvent<HTMLAnchorElement, MouseEvent>) => {
    e.preventDefault();
    e.stopPropagation();

    history.push(href);
  };

  const getDisplayedText = () => {
    if (props.customText) {
      return props.customText;
    }
    return `${props.user.name} ${props.user.surname}`;
  };

  return (
    <a className="ui-anchor" href={href} onClick={onAnchorClick}>
      {getDisplayedText()}
    </a>
  );
}
