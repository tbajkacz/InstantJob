export interface RegisterParams {
  name: string;
  surname: string;
  email: string;
  password: string;
  passwordConfirmation: string;
  roleId: number;
}

export interface ConfirmRegistrationParams {
  id: string;
}
