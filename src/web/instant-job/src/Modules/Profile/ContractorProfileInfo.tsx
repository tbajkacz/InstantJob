import { stat } from "fs";
import React, { useEffect, useState } from "react";
import { useHistory } from "react-router";
import { Button } from "reactstrap";
import { buildQuery } from "../../Common/buildQuery";
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

  if (!statistics) {
    return <LoadingIndicator promise={loadingPromise} />;
  }

  return (
    <div className="col-sm-12">
      <div className="ui-header">
        <h5>{statistics.assignedJobs} assigned jobs</h5>
        <Button size="sm" onClick={() => redirectToJobs(jobStatusName.Assigned)}>
          View assigned jobs
        </Button>
      </div>
      <div className="ui-header">
        <h5>{statistics.inProgressJobs} jobs in progress</h5>
        <Button size="sm" onClick={() => redirectToJobs(jobStatusName.InProgress)}>
          View jobs in progress
        </Button>
      </div>
      <div className="ui-header">
        <h5>{statistics.completedJobs} completed jobs</h5>
        <Button size="sm" onClick={() => redirectToJobs(jobStatusName.Completed)}>
          View completed jobs
        </Button>
      </div>
    </div>
    //--------------------
    //--------------------Completed jobs i skrócona lista. np
    //--------------------
  );
}
