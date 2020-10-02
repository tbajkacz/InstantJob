import React from "react";
import "./styles/App.scss";
import { HashRouter, Link, Switch, Route, Redirect, Router, useHistory, BrowserRouter } from "react-router-dom";
import { ProvideAuth } from "./Common/Auth/authContext";
import { Navbar, NavItem, Nav } from "reactstrap";
import UserMenu from "./Modules/Auth/UserMenu";
import routes from "./Common/routes";
import Home from "./Modules/Home/Home";
import JobsList from "./Modules/Jobs/JobsList";
import UserProfile from "./Modules/Profile/UserProfile";
import { Login } from "./Modules/Auth/Login/Login";
import Register from "./Modules/Auth/Register/Register";
import JobDetailedView from "./Modules/Jobs/JobDetailedView";
import Footer from "./Modules/Footer/Footer";
import ApplicationsList from "./Modules/Jobs/ApplicationsList";
import FindProfile from "./Modules/Profile/FindProfile";

function App() {
  return (
    <ProvideAuth>
      <BrowserRouter>
        <Navbar className="ui-element-bg-dark shadow">
          <div className="navbar-brand">
            <Link className="navbar-brand text-light mr-0" to={routes.Home}>
              Instant Job
            </Link>
          </div>
          <Nav className="mr-auto">
            <NavItem>
              <Link className="ui-nav-link" to={routes.Jobs}>
                Jobs
              </Link>
            </NavItem>
            <NavItem>
              <Link className="ui-nav-link" to={routes.SearchUser}>
                Find user
              </Link>
            </NavItem>
          </Nav>
          <UserMenu />
        </Navbar>
        <div className="mt-5 contentv">
          <Switch>
            <Route path={routes.Home}>
              <Home />
            </Route>
            <Route path={routes.SearchUser} exact>
              <FindProfile />
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
              <ApplicationsList />
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
