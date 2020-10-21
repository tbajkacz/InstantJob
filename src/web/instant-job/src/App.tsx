import React from "react";
import "./styles/App.scss";
import { Switch, Route, Redirect, BrowserRouter } from "react-router-dom";
import { ProvideAuth } from "./Common/Auth/authContext";
import routes from "./Common/routes";
import Home from "./Modules/Home/Home";
import JobsList from "./Modules/Jobs/JobsList";
import UserProfile from "./Modules/Profile/UserProfile";
import { Login } from "./Modules/Auth/Login/Login";
import Register from "./Modules/Auth/Register/Register";
import JobDetailedView from "./Modules/Jobs/JobDetailedView";
import Footer from "./Modules/Footer/Footer";
import JobApplicationsList from "./Modules/Jobs/JobApplicationsList";
import FindProfileModal from "./Modules/Profile/FindProfile";
import AppNavbar from "./Common/AppNavbar";
import ContractorApplications from "./Modules/Profile/ContractorApplications";
import Restricted from "./Common/Restricted";
import roles from "./Common/roles";

function App() {
  return (
    <ProvideAuth>
      <BrowserRouter>
        <AppNavbar />
        <div className="mt-5 contentv">
          <Switch>
            <Route path={routes.Home}>
              <Home />
            </Route>
            <Route path={routes.Profile} exact>
              <UserProfile />
            </Route>
            <Route path={routes.Jobs} exact>
              <JobsList />
            </Route>
            <Route path={routes.DetailedJob} exact>
              <JobDetailedView />
            </Route>
            <Route path={routes.Applications} exact>
              <JobApplicationsList />
            </Route>
            <Route path={routes.ContractorApplications} exact>
              <ContractorApplications />
            </Route>
            <Route path={routes.Login}>
              <Login className="d-flex justify-content-center mt-5" />
            </Route>
            <Route path={routes.Register}>
              <Register className="d-flex justify-content-center mt-5" />
            </Route>
            <Route>
              <Redirect to={routes.Home} />
            </Route>
          </Switch>
        </div>
        <div>
          <Footer className="footerv" />
        </div>
      </BrowserRouter>
    </ProvideAuth>
  );
}

export default App;
