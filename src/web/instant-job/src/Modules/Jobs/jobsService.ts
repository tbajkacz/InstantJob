import axios from "axios";
import { buildQuery } from "../../Common/buildQuery";
import ValidationErrors from "../../Common/validationErrors";
import {
  AcceptJobAssignmentCommand,
  ApplyForJobCommand,
  AssignContractorCommand,
  CancelAssignmentCommand,
  CancelJobCommand,
  CompleteJobCommand,
  GetJobDetailsQuery,
  GetJobsQuery,
  HasActiveApplicationQuery,
  HasActiveApplicationResponse,
  JobCategory,
  JobCreatedResponse,
  JobDetails,
  JobDifficulty,
  JobOverview,
  JobStatus,
  PostJobCommand,
  UpdateJobInformationCommand,
  WithdrawJobApplicationCommand,
} from "./jobsTypes";

class JobsService {
  GetJobs(query: GetJobsQuery) {
    return axios.get<JobOverview[]>(`/api/jobs${buildQuery(query)}`);
  }

  PostJob(params: PostJobCommand) {
    return axios.post<JobCreatedResponse>("/api/jobs", params);
  }

  GetJobDetails(params: GetJobDetailsQuery) {
    return axios.get<JobDetails>(`/api/jobs/${params.jobId}`);
  }

  UpdateJobInformation(params: UpdateJobInformationCommand) {
    return axios.patch(`/api/jobs/${params.jobId}`, params);
  }

  ApplyForJob(params: ApplyForJobCommand) {
    return axios.post(`/api/jobs/${params.jobId}/applications`, params);
  }

  HasActiveApplication(params: HasActiveApplicationQuery) {
    return axios.get<HasActiveApplicationResponse>(`/api/jobs/${params.jobId}/applications/hasActive`);
  }

  WithdrawJobApplication(params: WithdrawJobApplicationCommand) {
    return axios.delete(`/api/jobs/${params.jobId}/applications`, { headers: { "Content-Type": "application/json" } });
  }

  AssignContractor(params: AssignContractorCommand) {
    return axios.patch(`/api/jobs/${params.jobId}/assignment/assign`, params);
  }

  CancelAssignment(params: CancelAssignmentCommand) {
    return axios.patch(`/api/jobs/${params.jobId}/assignment/cancel`, params);
  }

  AcceptJobAssignment(params: AcceptJobAssignmentCommand) {
    return axios.patch(`/api/jobs/${params.jobId}/assignment/accept`, params);
  }

  CancelJobOffer(params: CancelJobCommand) {
    return axios.delete(`/api/jobs/${params.jobId}`);
  }

  CompleteJob(params: CompleteJobCommand) {
    return axios.patch(`/api/jobs/${params.jobId}/complete`, params);
  }

  GetJobDifficulties() {
    return axios.get<JobDifficulty[]>("/api/jobs/difficulties");
  }

  GetJobCategories() {
    return axios.get<JobCategory[]>("/api/categories");
  }

  GetJobStatuses() {
    return axios.get<JobStatus[]>("/api/jobs/statuses");
  }
}

export const jobsService = new JobsService();
