import { Role } from "../../Common/Auth/authTypes";

export interface UserProfileInfo {
  name: string;
  surname: string;
  email: string;
  role: Role;
  picture: string;
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
}

export interface MandatorStatistics {
  postedJobs: number;
}

export interface GetStatisticsQuery {
  id: string;
}
