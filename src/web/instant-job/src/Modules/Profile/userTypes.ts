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
  assignedJobs: number;
  inProgressJobs: number;
  completedJobs: number;
  averageRating: number;
  applicationsCount: number;
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
