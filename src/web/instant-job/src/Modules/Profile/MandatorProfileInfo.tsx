import React, { useEffect, useState } from "react";
import { useHistory } from "react-router";
import { Button } from "reactstrap";
import { buildQuery } from "../../Common/buildQuery";
import LoadingIndicator from "../../Common/LoadingIndicator";
import routes from "../../Common/routes";
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

  const redirectToJobs = () => {
    const query: JobsListQuery = {
      mandatorId: props.userId,
      status: jobStatusName.Any,
      includeExpired: true,
    };

    history.push(`${routes.Jobs}${buildQuery(query)}`);
  };

  return (
    <div className="col-sm-12">
      <div className="ui-header">
        <h5>{statistics.postedJobs} posted jobs</h5>
        <Button size="sm" onClick={redirectToJobs}>
          View posted jobs
        </Button>
      </div>
    </div>
  );
}
