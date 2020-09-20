import React, { useEffect, useState } from "react";
import { useParams } from "react-router";
import LoadingIndicator from "../../Common/LoadingIndicator";
import { jobsService } from "./jobsService";
import { JobDetails } from "./jobsTypes";
import { combineClasses } from "./../../Common/componentUtility";

export interface JobDetailedViewProps {
  className?: string;
}

export interface RouteProps {
  jobId: string;
}

export default function JobDetailedView(props: JobDetailedViewProps) {
  const { jobId } = useParams<RouteProps>();

  const [jobDetails, setJobDetails] = useState<JobDetails>();
  const [loadingPromise, setLoadingPromise] = useState<Promise<any>>();

  useEffect(() => {
    setLoadingPromise(
      jobsService.GetJobDetails({ jobId }).then((r) => {
        setJobDetails(r.data);
      })
    );
  }, []);

  return (
    <div className={combineClasses(props.className, "ui-list-flex-container")}>
      <LoadingIndicator promise={loadingPromise}>
        {jobDetails ? <h1>{jobDetails.title}</h1> : undefined}
      </LoadingIndicator>
    </div>
  );
}
