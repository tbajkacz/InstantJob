const routes = {
  Home: "/home",
  Login: "/login",
  Register: "/register",
  Profile: "/profile/:userId",
  Jobs: "/jobs",
  DetailedJob: "/jobs/:jobId",
  Categories: "/categories",
  DetailedCategory: "/categories/:categoryName",
  Applications: "/jobs/:jobId/applications",
  SearchUser: "/profile/find",
  ContractorApplications: "/applications",
};

export const routeParams = {
  jobId: ":jobId",
  userId: ":userId",
};

export default routes;
