import React, { useEffect, useState } from "react";
import { useHistory } from "react-router";
import { Button } from "reactstrap";
import { buildQuery } from "../../Common/buildQuery";
import { combineClasses } from "../../Common/componentUtility";
import LoadingIndicator from "../../Common/LoadingIndicator";
import routes, { routeParams } from "../../Common/routes";
import { JobsListQuery } from "../Jobs/JobsList";
import { jobStatusName } from "../Jobs/jobsTypes";
import { userService } from "./userService";
import { MandatorStatistics } from "./userTypes";

interface MandatorProfileInfoProps {
  userId: string;
}

export default function MandatorProfileInfo(props: MandatorProfileInfoProps) {
  const history = useHistory();

  const [statistics, setStatistics] = useState<MandatorStatistics>();

  const [loadingPromise, setLoadingPromise] = useState<Promise<any>>();

  useEffect(() => {
    setLoadingPromise(userService.getMandatorStatistics({ id: props.userId }).then((r) => setStatistics(r.data)));
  }, []);

  if (!statistics) {
    return <LoadingIndicator promise={loadingPromise} />;
  }

  const redirectToJobs = (status: string) => {
    const query: JobsListQuery = {
      mandatorId: props.userId,
      status: status,
      includeExpired: true,
    };

    history.push(`${routes.Jobs}${buildQuery(query)}`);
  };

  const redirectToJob = (id: string) => history.push(`${routes.Jobs}/${id}`);

  return (
    <div className="col-sm-12 row">
      <div className="col-sm-4">
        <div className="ui-header">
          <h5>{statistics.postedJobsCount} posted jobs</h5>
          <ul className="ui-list-dark">
            {statistics.postedJobs.slice(0, 5).map((j) => (
              <li
                className={combineClasses("ui-list-item-dark-interactive", "row", "pt-1 pb-1")}
                onClick={() => redirectToJob(j.id)}
              >
                {j.title}
              </li>
            ))}
          </ul>
          <Button className="btn-block mt-2" size="sm" onClick={() => redirectToJobs(jobStatusName.Any)}>
            View all posted jobs
          </Button>
        </div>
        <div className="ui-header">
          <h5>{statistics.postedJobsInProgressCount} posted jobs in progress</h5>
          <ul className="ui-list-dark">
            {statistics.postedJobsInProgress.map((j) => (
              <li
                className={combineClasses("ui-list-item-dark-interactive", "row", "pt-1 pb-1")}
                onClick={() => redirectToJob(j.id)}
              >
                {j.title}
              </li>
            ))}
          </ul>
          <Button className="btn-block mt-2" size="sm" onClick={() => redirectToJobs(jobStatusName.InProgress)}>
            View posted jobs in progress details
          </Button>
        </div>
        <div className="ui-header">
          <h5>{statistics.postedJobsCompletedCount} posted jobs completed</h5>
          <ul className="ui-list-dark">
            {statistics.postedJobsCompleted.map((j) => (
              <li
                className={combineClasses("ui-list-item-dark-interactive", "row", "pt-1 pb-1")}
                onClick={() => redirectToJob(j.id)}
              >
                {j.title}
              </li>
            ))}
          </ul>
          <Button className="btn-block mt-2" size="sm" onClick={() => redirectToJobs(jobStatusName.Completed)}>
            View posted jobs completed details
          </Button>
        </div>
      </div>
      <div className="col-sm-8">
        <div className="ui-header">
          <h5>{statistics.postedJobsWaitingForAssignmentCount} jobs awaiting assignment</h5>
          <ul className="ui-list-dark">
            {statistics.postedJobsWaitingForAssignment.map((j) => (
              <li
                className={combineClasses("ui-list-item-dark-interactive", "row", "pt-1 pb-1")}
                onClick={() => history.push(routes.Applications.replace(routeParams.jobId, j.id))}
              >
                {j.title}
              </li>
            ))}
          </ul>
        </div>
      </div>
    </div>
  );
}
