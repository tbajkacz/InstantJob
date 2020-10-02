import React from "react";
import { useAuth } from "../../Common/Auth/authContext";
import { Link } from "react-router-dom";
import NavbarButton from "./NavbarButton";
import routes from "../../Common/routes";
import UserProfileAnchor from "../../Common/UserProfileAnchor";

export default React.memo(function UserMenu() {
  const auth = useAuth();

  return auth.currentUser ? (
    <div className="text-light">
      <p className="mr-2 d-inline">
        Logged in as <UserProfileAnchor user={auth.currentUser} />{" "}
      </p>
      <NavbarButton onClick={() => auth.signOut()}>Sign out</NavbarButton>
    </div>
  ) : (
    <div>
      <Link to={routes.Login}>
        <NavbarButton>Sign in</NavbarButton>
      </Link>
      <Link className="ml-1" to={routes.Register}>
        <NavbarButton>Sign up</NavbarButton>
      </Link>
    </div>
  );
});
