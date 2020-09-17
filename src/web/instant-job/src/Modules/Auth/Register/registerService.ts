import axios from "axios";
import { RegisterParams, ConfirmRegistrationParams } from "./registerTypes";

class RegisterService {
  register(params?: RegisterParams) {
    return axios.post("api/register", params);
  }

  confirmRegistration(params?: ConfirmRegistrationParams) {
    return axios.patch("api/register", params);
  }
}

export const registerService = new RegisterService();
