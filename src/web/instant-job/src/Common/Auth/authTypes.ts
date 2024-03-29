export interface Role {
  id: number;
  name: string;
}

export interface CurrentUser {
  id: string;
  name: string;
  surname: string;
  email: string;
  role: Role;
}

export interface AuthParams {
  email: string;
  password: string;
}

export interface Auth {
  currentUser?: CurrentUser;
  signIn: (params?: AuthParams) => Promise<false | undefined>;
  signOut: () => void;
  promise?: Promise<any>;
}
