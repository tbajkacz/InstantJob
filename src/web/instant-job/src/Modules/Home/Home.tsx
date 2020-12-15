import * as React from "react";
import { useEffect } from "react";
import { useState } from "react";
import { Link, useHistory } from "react-router-dom";
import { useAuth } from "../../Common/Auth/authContext";
import { buildQuery } from "../../Common/buildQuery";
import LoadingIndicator from "../../Common/LoadingIndicator";
import Restricted from "../../Common/Restricted";
import roles from "../../Common/roles";
import routes from "../../Common/routes";
import { JobsListQuery } from "../Jobs/JobsList";
import { jobStatusName } from "../Jobs/jobsTypes";
import { userService } from "../Profile/userService";
import { ContractorStatistics, MandatorStatistics } from "../Profile/userTypes";

export default function Home() {
  const auth = useAuth();
  let userName = auth.currentUser ? auth.currentUser.name + " " + auth.currentUser.surname : "Guest";
  let userRole = auth.currentUser ? auth.currentUser.role.name : "guest";

  const history = useHistory();

  const onRegisterClick = (e: React.MouseEvent<HTMLAnchorElement, MouseEvent>) => {
    e.preventDefault();
    e.stopPropagation();

    history.push(routes.Register);
  };

  const [contractorStatistics, setContractorStatistics] = useState<ContractorStatistics>();
  const [mandatorStatistics, setMandatorStatistics] = useState<MandatorStatistics>();
  const [loadingPromise, setLoadingPromise] = useState<Promise<any>>();

  useEffect(() => {
    if (!auth.currentUser) {
      return;
    }

    if (userRole === roles.mandator) {
      setLoadingPromise(
        userService.getMandatorStatistics({ id: auth.currentUser.id }).then((r) => setMandatorStatistics(r.data))
      );
    } else if (userRole === roles.contractor) {
      setLoadingPromise(
        userService.getContractorStatistics({ id: auth.currentUser.id }).then((r) => setContractorStatistics(r.data))
      );
    }
  }, []);

  const renderJobsModuleTextDescription = () => {
    switch (userRole) {
      case roles.contractor:
        return "Browse and apply for job offers";
      case roles.mandator:
        return "Browse and post new job offers";
      default:
        return "Browse job offers";
    }
  };

  const renderContractorApplicationsCard = () => {
    if (!contractorStatistics) {
      return null;
    }

    return (
      <LoadingIndicator promise={loadingPromise}>
        <div className="ui-card-dark">
          <div className="card-body">
            <h5 className="card-title">Your applications</h5>
            <p className="card-text">You have {contractorStatistics.applicationsCount} active applications</p>
            <Link to={routes.ContractorApplications} className="btn btn-primary">
              Your applications
            </Link>
          </div>
        </div>
      </LoadingIndicator>
    );
  };

  const buildJobsRedirect = () => {
    if (!contractorStatistics || !auth.currentUser) {
      return "";
    }

    const query: JobsListQuery = {
      contractorId: auth.currentUser!.id,
      status: jobStatusName.InProgress,
      includeExpired: true,
    };

    return `${routes.Jobs}${buildQuery(query)}`;
  };

  const renderContractorJobsInProgressCard = () => {
    if (!contractorStatistics) {
      return null;
    }

    return (
      <LoadingIndicator promise={loadingPromise}>
        <div className="ui-card-dark">
          <div className="card-body">
            <h5 className="card-title">Your jobs in progress</h5>
            <p className="card-text">You have {contractorStatistics.inProgressJobsCount} jobs in progress</p>
            <Link to={buildJobsRedirect()} className="btn btn-primary">
              Your jobs in progress
            </Link>
          </div>
        </div>
      </LoadingIndicator>
    );
  };

  return (
    <div className="col-sm-8 offset-sm-2">
      <div className="card-columns">
        <Restricted roles={[roles.mandator, roles.contractor, roles.admin]}>
          <div className="ui-card-dark">
            <div className="card-body">
              <h5 className="card-title">Welcome, {userName}!</h5>
              <p className="card-text">
                <small className="text-muted">Your role in the application: {userRole}</small>
              </p>
            </div>
          </div>
        </Restricted>

        <Restricted roles={[roles.guest]}>
          <div className="ui-card-dark">
            <div className="card-body">
              <h5 className="card-title">Sign in</h5>
              <p className="card-text">Already have an account?</p>
              <Link to={routes.Login} className="btn btn-primary">
                Sign in
              </Link>
            </div>
          </div>
        </Restricted>

        <Restricted roles={[roles.guest]}>
          <div className="ui-card-dark">
            <div className="card-body">
              <h5 className="card-title">Register</h5>
              <p className="card-text">Need an account? </p>
              <a href={routes.Register} className="btn btn-primary" onClick={onRegisterClick}>
                Register now
              </a>
            </div>
          </div>
        </Restricted>

        <Restricted roles={[roles.guest, roles.contractor, roles.mandator]}>
          <div className="ui-card-dark">
            <div className="card-body">
              <h5 className="card-title">Jobs</h5>
              <p className="card-text">{renderJobsModuleTextDescription()}</p>
              <Link to={routes.Jobs} className="btn btn-primary">
                Jobs
              </Link>
            </div>
          </div>
        </Restricted>

        <Restricted roles={[roles.contractor]}>{renderContractorApplicationsCard()}</Restricted>
        <Restricted roles={[roles.contractor]}>{renderContractorJobsInProgressCard()}</Restricted>
      </div>
    </div>
  );
}
