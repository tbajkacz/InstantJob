import { Role } from "../../Common/Auth/authTypes";

export interface UserProfileInfo {
  name: string;
  surname: string;
  email: string;
  role: Role;
  picture: string;
  description: string;
  age: number | undefined;
  creationDate: Date;
}

export interface GetUserByIdQuery {
  userId: string;
}

export interface ContractorStatistics {
  assignedJobsCount: number;
  inProgressJobsCount: number;
  completedJobsCount: number;
  averageRating: number;
  applicationsCount: number;
  completedJobs: JobStatistic[];
  assignedJobs: JobStatistic[];
  inProgressJobs: JobStatistic[];
  activeApplications: JobApplicationStatistic[];
}
export interface JobStatistic {
  id: string;
  title: string;
}

export interface JobApplicationStatistic {
  jobId: string;
  jobTitle: string;
}

export interface MandatorStatistics {
  postedJobs: number;
}

export interface GetStatisticsQuery {
  id: string;
}

export interface FindUserByNameQuery {
  search: string;
}

export interface FindUserByNameResponse {
  users: UserBasicInfo[];
}

export interface UserBasicInfo {
  id: string;
  name: string;
  surname: string;
}

export interface ContractorApplication {
  jobId: string;
  jobTitle: string;
  applicationDate: Date;
}
