import axios from "axios";
import { buildQuery } from "../../Common/buildQuery";
import {
  AcceptJobAssignmentCommand,
  ApplyForJobCommand,
  AssignContractorCommand,
  CancelJobCommand,
  CompleteJobCommand,
  GetJobDetailsQuery,
  GetJobsQuery,
  JobDetails,
  JobDifficulty,
  JobOverview,
  PostJobCommand,
  UpdateJobInformationCommand,
  WithdrawJobApplicationCommand,
} from "./jobsTypes";

class JobsService {
  GetJobs(query: GetJobsQuery) {
    return axios.get<JobOverview[]>(`/api/jobs${buildQuery(query)}`);
  }

  PostJob(params: PostJobCommand) {
    return axios.post("/api/jobs", params);
  }

  GetJobDetails(params: GetJobDetailsQuery) {
    return axios.get<JobDetails>(`/api/jobs/${params.jobId}`);
  }

  UpdateJobInformation(params: UpdateJobInformationCommand) {
    return axios.patch(`/api/jobs/${params.jobId}`, params);
  }

  ApplyForJob(params: ApplyForJobCommand) {
    return axios.post(`/api/jobs/${params.jobId}/applications`);
  }

  WithdrawJobApplication(params: WithdrawJobApplicationCommand) {
    return axios.delete(`/api/jobs/${params.jobId}/applications`);
  }

  AssignContractor(params: AssignContractorCommand) {
    return axios.patch(`/api/jobs/${params.jobId}/assignment/assign`);
  }

  AcceptJobAssignment(params: AcceptJobAssignmentCommand) {
    return axios.patch(`/api/jobs/${params.jobId}/assignment/accept`);
  }

  CancelJobOffer(params: CancelJobCommand) {
    return axios.delete(`/api/jobs/${params.jobId}`);
  }

  CompleteJob(params: CompleteJobCommand) {
    return axios.patch(`/api/jobs/${params.jobId}/complete`);
  }

  GetJobDifficulties() {
    return axios.get<JobDifficulty[]>("/api/jobs/difficulties");
  }
}

export const jobsService = new JobsService();
