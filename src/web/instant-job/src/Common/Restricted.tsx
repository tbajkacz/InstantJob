import React, { useState, useEffect } from "react";
import { Redirect } from "react-router";
import routes from "./routes";
import { useAuth } from "./Auth/authContext";
import roles from "./roles";

interface RestrictedProps {
  children: JSX.Element | JSX.Element[] | null;
  redirectToLogin?: boolean;
  roles: string[];
}

const redirect = <Redirect to={routes.Login} />;

export default function Restricted(props: RestrictedProps) {
  const auth = useAuth();
  const [complete, setComplete] = useState(false);

  const callback = () => {
    setComplete(true);
  };

  useEffect(() => {
    if (auth.promise) {
      auth.promise.then(callback, callback);
    }
  }, [auth.promise]);

  const hasAnyOfRoles = () =>
    auth.currentUser
      ? props.roles.includes(auth.currentUser.role.name) ||
        (auth.currentUser.role.name === roles.admin && !props.roles.includes(roles.guest))
      : props.roles.includes(roles.guest);

  const redirectOrNull = () => (props.redirectToLogin && complete ? redirect : null);

  return <>{hasAnyOfRoles() ? props.children : redirectOrNull()}</>;
}
