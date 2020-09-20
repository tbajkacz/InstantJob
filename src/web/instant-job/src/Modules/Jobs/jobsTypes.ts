export interface GetJobsQuery {
  categoryId?: string;
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

export interface WithdrawJobApplicationCommand {
  jobId: string;
}

export interface AssignContractorCommand {
  jobId: string;
  contractorId: string;
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
}

export interface JobDetails {
  id: string;
  title: string;
  description: string;
  applications: JobApplication[];
  price: number;
  postedDate: Date;
  deadline: Date;
  difficulty: JobDifficulty;
  wasCanceled: boolean;
  category: JobCategory;
  mandator: Mandator;
  contractor: Contractor;
  isCompleted: boolean;
  isInProgress: boolean;
}

export interface JobCategory {
  id: string;
  name: string;
}

export interface JobApplication {
  contractor: Contractor;
  applicationDate: Date;
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
