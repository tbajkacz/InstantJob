import axios from "axios";
import { Role } from "./../../Common/Auth/authTypes";
import {
  ContractorStatistics,
  GetStatisticsQuery,
  GetUserByIdQuery,
  MandatorStatistics,
  UserProfileInfo,
} from "./userTypes";
class UserService {
  getUserById(query: GetUserByIdQuery) {
    return axios.get<UserProfileInfo>(`/api/users/${query.userId}`);
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
}

export const userService = new UserService();
