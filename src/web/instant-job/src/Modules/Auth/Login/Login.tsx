import React, { useState } from "react";
import { useAuth } from "../../../Common/Auth/authContext";
import { Redirect } from "react-router";
import "../../../styles/Login.scss";
import { faUser, faKey } from "@fortawesome/free-solid-svg-icons";
import { AuthParams } from "../../../Common/Auth/authTypes";
import { CardHeader, Form, CardFooter, FormGroup, Button, Label } from "reactstrap";
import { FormInput, FormInputConfig } from "../../../Common/FormInput";
import routes from "../../../Common/routes";
import { combineClasses } from "./../../../Common/componentUtility";
import { Link } from "react-router-dom";

interface LoginProps {
  className?: string;
}

export function Login(props: LoginProps) {
  const [params, setParams] = useState<AuthParams>({
    email: "",
    password: "",
  });

  const [signInFailed, setsignInFailed] = useState(false);

  const auth = useAuth();
  //const { validationResponse, setValidationResponse } = useState();

  const onSubmit = (e: React.MouseEvent<any, MouseEvent>) => {
    setsignInFailed(false);
    e.preventDefault();
    auth.signIn(params).then((response) => {
      if (response === false) {
        setsignInFailed(true);
      }
    });
  };

  const onChange = (name: string, value: string) => {
    setParams({ ...params, [name]: value });
  };

  const config: FormInputConfig = {
    onChange,
    //errors,
  };

  return auth.currentUser ? (
    <Redirect to={routes.Home} />
  ) : (
    <div className={props.className}>
      <div className="ui-login-card shadow">
        <CardHeader>
          <h3 className="text-white">Sign In</h3>
        </CardHeader>
        <div className="ui-login-card-body">
          <Form>
            <Label className="text-danger" hidden={!signInFailed}>
              {signInFailed ? "Invalid user credentials" : ""}
            </Label>
            <FormInput className="flex-fill" config={config} type="text" name="email" icon={faUser} />
            <FormInput className="flex-fill" config={config} type="password" name="password" icon={faKey} />
            {/* <FormGroup className="ui-login-remember-me">
              <Input type="checkbox" onChange={(e) => setParams({ ...params!, rememberMe: e.currentTarget.checked })} />
              <Label>Remember me</Label>
            </FormGroup> */}
            <FormGroup>
              <Button color="primary" block={true} type="submit" onClick={onSubmit}>
                Login
              </Button>
            </FormGroup>
          </Form>
        </div>
        <CardFooter>
          <small className="text-white">
            Don't have an account? <Link to={routes.Register}>Click here to register</Link>
          </small>
        </CardFooter>
      </div>
    </div>
  );
}
