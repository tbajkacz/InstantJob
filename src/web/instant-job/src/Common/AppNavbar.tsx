import React, { useState } from "react";
import { Link } from "react-router-dom";
import { Nav, Navbar, NavItem } from "reactstrap";
import UserMenu from "../Modules/Auth/UserMenu";
import routes from "./routes";
import { useLocation } from "react-router";
import Restricted from "./Restricted";
import roles from "./roles";
import { useAuth } from "./Auth/authContext";
import { jobStatusName } from "../Modules/Jobs/jobsTypes";
import { buildQuery } from "./buildQuery";
import FindProfileModal from "../Modules/Profile/FindProfile";

export default function AppNavbar() {
  const [isFindUserModalOpen, setIsFindUserModalOpen] = useState(false);
  const toggleFindUserModal = () => {
    setIsFindUserModalOpen(!isFindUserModalOpen);
  };

  const auth = useAuth();
  const location = useLocation();

  const buildMandatorJobsQuery = () => {
    if (!auth.currentUser) {
      return;
    }
    return buildQuery({
      mandatorId: auth.currentUser.id,
      status: jobStatusName.Any,
      includeExpired: true,
    });
  };

  const buildContractorJobsQuery = (status: string) => {
    if (!auth.currentUser) {
      return;
    }
    return buildQuery({
      contractorId: auth.currentUser.id,
      status,
      includeExpired: true,
    });
  };

  return (
    <Navbar className="ui-element-bg-dark shadow">
      <div className="navbar-brand">
        <Link className="navbar-brand text-light mr-0" to={routes.Home}>
          Instant Job
        </Link>
      </div>
      <Nav className="mr-auto">
        <NavItem>
          <Link className="ui-nav-link" to={`${location.pathname}${location.search}`} onClick={toggleFindUserModal}>
            Find user
          </Link>
        </NavItem>
        <NavItem>
          <Link className="ui-nav-link" to={routes.Jobs}>
            Jobs
          </Link>
        </NavItem>
        <Restricted roles={[roles.mandator]}>
          <NavItem>
            <Link className="ui-nav-link" to={`${routes.Jobs}${buildMandatorJobsQuery()}`}>
              Your jobs
            </Link>
          </NavItem>
        </Restricted>
        <Restricted roles={[roles.contractor]}>
          <NavItem>
            <Link className="ui-nav-link" to={`${routes.Jobs}${buildContractorJobsQuery(jobStatusName.InProgress)}`}>
              Your jobs
            </Link>
          </NavItem>
          <NavItem>
            <Link className="ui-nav-link" to={routes.ContractorApplications}>
              Your applications
            </Link>
          </NavItem>
        </Restricted>
      </Nav>
      <UserMenu />
      <FindProfileModal isOpen={isFindUserModalOpen} toggle={toggleFindUserModal} />
    </Navbar>
  );
}
