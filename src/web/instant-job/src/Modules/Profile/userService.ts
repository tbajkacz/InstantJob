import axios from "axios";
import { Role } from "./../../Common/Auth/authTypes";
class UserService {
  getAvailableRoles() {
    return axios.get<Role[]>("api/users/roles");
  }
}

export const userService = new UserService();
