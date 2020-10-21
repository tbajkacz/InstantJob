import axios from "axios";
import { buildQuery } from "../../Common/buildQuery";
import { Role } from "./../../Common/Auth/authTypes";
import {
  ContractorApplication,
  ContractorStatistics,
  FindUserByNameQuery,
  FindUserByNameResponse,
  GetStatisticsQuery,
  GetUserByIdQuery,
  MandatorStatistics,
  UserProfileInfo,
} from "./userTypes";
class UserService {
  getUserById(query: GetUserByIdQuery) {
    return axios.get<UserProfileInfo>(`/api/users/${query.userId}`);
  }

  findByName(query: FindUserByNameQuery) {
    return axios.get<FindUserByNameResponse>(`/api/users${buildQuery(query)}`);
  }

  getAvailableRoles() {
    return axios.get<Role[]>("/api/users/roles");
  }

  getContractorStatistics(query: GetStatisticsQuery) {
    return axios.get<ContractorStatistics>(`/api/statistics/contractor/${query.id}`);
  }

  getMandatorStatistics(query: GetStatisticsQuery) {
    return axios.get<MandatorStatistics>(`/api/statistics/mandator/${query.id}`);
  }

  getContractorApplications() {
    return axios.get<ContractorApplication[]>(`/api/contractors/applications`);
  }
}

export const userService = new UserService();
