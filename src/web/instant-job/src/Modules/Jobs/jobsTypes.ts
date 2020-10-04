export interface GetJobsQuery {
  categoryId?: string;
  searchString?: string;
  difficultyId?: number;
  skip?: number;
  count?: number;
}

export interface PostJobCommand {
  title: string;
  description: string;
  price?: number;
  deadline: Date;
  difficultyId: number;
  categoryId: string;
}

export interface GetJobDetailsQuery {
  jobId: string;
}

export interface UpdateJobInformationCommand {
  jobId: string;
  title: string;
  description: string;
  price?: number;
  deadline: Date;
  difficultyId: number;
}

export interface ApplyForJobCommand {
  jobId: string;
}

export interface HasActiveApplicationQuery {
  jobId: string;
}

export interface HasActiveApplicationResponse {
  hasActiveApplication: boolean;
}

export interface WithdrawJobApplicationCommand {
  jobId: string;
}

export interface AssignContractorCommand {
  jobId: string;
  contractorId: string;
}

export interface CancelAssignmentCommand {
  jobId: string;
}

export interface AcceptJobAssignmentCommand {
  jobId: string;
}

export interface CancelJobCommand {
  jobId: string;
}

export interface CompleteJobCommand {
  jobId: string;
}

export interface JobOverview {
  id: string;
  title: string;
  description: string;
  price: number;
  postedDate: Date;
  difficulty: JobDifficulty;
  category: JobCategory;
  mandator: Mandator;
  status: JobStatus;
}

export interface JobDetails {
  id: string;
  title: string;
  description: string;
  applications: JobApplication[];
  completionInfo: JobCompletionInfo;
  price: number;
  postedDate: Date;
  deadline: Date;
  difficulty: JobDifficulty;
  category: JobCategory;
  mandator: Mandator;
  contractor: Contractor;
  status: JobStatus;
}

export interface JobCategory {
  id: string;
  name: string;
}

export interface JobApplication {
  contractor: Contractor;
  applicationDate: Date;
}

export interface JobCompletionInfo {
  completionDate: Date;
  comment: string;
  rating: number | undefined;
}

export interface JobDifficulty {
  id: number;
  name: string;
}

export interface Mandator {
  id: string;
  name: string;
  surname: string;
}

export interface Contractor {
  id: string;
  name: string;
  surname: string;
}

export interface JobStatus {
  id: number;
  name: string;
  isInProgress: boolean;
  isAssigned: boolean;
  isCompleted: boolean;
  isAvailable: boolean;
  isCanceled: boolean;
}

export const jobStatusName = {
  Available: "Available",
  Assigned: "Assigned",
  InProgress: "InProgress",
  Completed: "Completed",
  Canceled: "Canceled",
  Any: "Any",
};
