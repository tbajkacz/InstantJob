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
};

export const routeParams = {
  jobId: ":jobId",
  userId: ":userId",
};

export default routes;
