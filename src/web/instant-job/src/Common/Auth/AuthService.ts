import axios from "axios";
import { AuthParams, CurrentUser } from "./authTypes";

class AuthService {
  SignIn(params?: AuthParams) {
    return axios.post("api/auth/signin", params);
  }

  SignOut() {
    return axios.post("api/auth/signout");
  }

  GetCurrentUser() {
    return axios.get<CurrentUser>("api/auth/user");
  }
}

export const authService = new AuthService();
