import { stat } from "fs";
import React, { useEffect, useState } from "react";
import { useHistory } from "react-router";
import { Button } from "reactstrap";
import { buildQuery } from "../../Common/buildQuery";
import { combineClasses } from "../../Common/componentUtility";
import LoadingIndicator from "../../Common/LoadingIndicator";
import routes from "../../Common/routes";
import { JobsListQuery } from "../Jobs/JobsList";
import { jobStatusName } from "../Jobs/jobsTypes";
import { userService } from "./userService";
import { ContractorStatistics } from "./userTypes";

export interface ContractorProfileProps {
  userId: string;
}

export default function ContractorProfileInfo(props: ContractorProfileProps) {
  const [statistics, setStatistics] = useState<ContractorStatistics>();

  const [loadingPromise, setLoadingPromise] = useState<Promise<any>>();

  const history = useHistory();

  useEffect(() => {
    setLoadingPromise(userService.getContractorStatistics({ id: props.userId }).then((r) => setStatistics(r.data)));
  }, []);

  const redirectToJobs = (status: string) => {
    const query: JobsListQuery = {
      contractorId: props.userId,
      status,
      includeExpired: true,
    };

    history.push(`${routes.Jobs}${buildQuery(query)}`);
  };

  const redirectToJob = (id: string) => history.push(`${routes.Jobs}/${id}`);

  if (!statistics) {
    return <LoadingIndicator promise={loadingPromise} />;
  }

  return (
    <div className="col-sm-12 row">
      <div className="col-sm-4">
        <div className="ui-header">
          <h5>{statistics.completedJobsCount} completed jobs</h5>
          <ul className="ui-list-dark">
            {statistics.completedJobs.map((j) => (
              <li
                className={combineClasses("ui-list-item-dark-interactive", "row", "pt-1 pb-1")}
                onClick={() => redirectToJob(j.id)}
              >
                {j.title}
              </li>
            ))}
          </ul>
          <Button className="btn-block mt-2" size="sm" onClick={() => redirectToJobs(jobStatusName.Completed)}>
            View completed jobs details
          </Button>
        </div>
        <div className="ui-header">
          <h5>{statistics.assignedJobsCount} assigned jobs</h5>
          <ul className="ui-list-dark">
            {statistics.assignedJobs.map((j) => (
              <li
                className={combineClasses("ui-list-item-dark-interactive", "row", "pt-1 pb-1")}
                onClick={() => redirectToJob(j.id)}
              >
                {j.title}
              </li>
            ))}
          </ul>
          <Button className="btn-block mt-2" size="sm" onClick={() => redirectToJobs(jobStatusName.Assigned)}>
            View assigned jobs details
          </Button>
        </div>
        <div className="ui-header">
          <h5>{statistics.inProgressJobsCount} jobs in progress</h5>
          <ul className="ui-list-dark">
            {statistics.inProgressJobs.map((j) => (
              <li
                className={combineClasses("ui-list-item-dark-interactive", "row", "pt-1 pb-1")}
                onClick={() => redirectToJob(j.id)}
              >
                {j.title}
              </li>
            ))}
          </ul>
          <Button className="btn-block mt-2" size="sm" onClick={() => redirectToJobs(jobStatusName.InProgress)}>
            View jobs in progress details
          </Button>
        </div>
      </div>
      <div className="col-sm-8">
        <div className="ui-header">
          <h5>Active applications</h5>
          <ul className="ui-list-dark">
            {statistics.activeApplications.map((a) => (
              <li
                className={combineClasses("ui-list-item-dark-interactive", "row", "pt-1 pb-1")}
                onClick={() => redirectToJob(a.jobId)}
              >
                {a.jobTitle}
              </li>
            ))}
          </ul>
        </div>
      </div>
    </div>
    //--------------------
    //--------------------Completed jobs i skrócona lista. np
    //--------------------
  );
}
