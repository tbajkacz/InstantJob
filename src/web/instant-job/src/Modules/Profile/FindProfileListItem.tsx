import React from "react";
import { useHistory } from "react-router";
import routes, { routeParams } from "../../Common/routes";
import { UserBasicInfo } from "./userTypes";

interface FindProfileListItemProps {
  userInfo: UserBasicInfo;
}

export default function FindProfileListItem(props: FindProfileListItemProps) {
  const history = useHistory();

  const redirectToUserProfile = () => {
    history.push(`${routes.Profile.replace(routeParams.userId, props.userInfo.id)}`);
  };

  return (
    <li className="ui-list-item-dark-interactive" onClick={redirectToUserProfile}>
      {props.userInfo.name} {props.userInfo.surname}
    </li>
  );
}
