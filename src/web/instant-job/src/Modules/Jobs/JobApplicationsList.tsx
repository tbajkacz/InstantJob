import React, { useEffect, useState } from "react";
import { useParams } from "react-router";
import LoadingIndicator from "../../Common/LoadingIndicator";
import { jobsService } from "./jobsService";
import { JobDetails } from "./jobsTypes";
import JobApplicationsListItem from "./JobApplicationsListItem";

export interface JobApplicationsListProps {
  className?: string;
}

export interface JobApplicationsListRouteProps {
  jobId: string;
}

export default function JobApplicationsList(props: JobApplicationsListProps) {
  const [jobDetails, setJobDetails] = useState<JobDetails>();
  const queryParams = useParams<JobApplicationsListRouteProps>();

  const [loadingPromise, setLoadingPromise] = useState<Promise<any>>();

  const refreshJobDetails = () => {
    return jobsService.GetJobDetails({ jobId: queryParams.jobId }).then((r) => setJobDetails(r.data));
  };

  useEffect(() => {
    setLoadingPromise(refreshJobDetails());
  }, []);

  const onAction = () => {
    refreshJobDetails();
  };

  if (!jobDetails) {
    return null;
  }

  return (
    <LoadingIndicator promise={loadingPromise}>
      <div className={props.className}>
        <div className="ui-flex-container">
          <div className="ui-wrapper col-sm-9">
            <h3 className="ui-header">{`${jobDetails.applications.length} applications for ${jobDetails.title}`}</h3>
            <ul className="ui-list-dark">
              {jobDetails.applications.map((a) => (
                <JobApplicationsListItem
                  key={a.applicationDate.toString()}
                  application={a}
                  jobId={jobDetails.id}
                  onAction={onAction}
                  assignedContractor={jobDetails.contractor}
                  status={jobDetails.status}
                />
              ))}
            </ul>
          </div>
        </div>
      </div>
    </LoadingIndicator>
  );
}
