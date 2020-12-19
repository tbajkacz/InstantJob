import React, { useState, useEffect } from "react";
import { RegisterParams } from "./registerTypes";
import { useAuth } from "../../../Common/Auth/authContext";
import { Redirect } from "react-router";
import routes from "../../../Common/routes";
import { CardHeader, Form, FormGroup, Button, CardFooter } from "reactstrap";
import { FormInput, FormInputConfig } from "../../../Common/FormInput";
import ValidationErrors from "../../../Common/validationErrors";
import { registerService } from "./registerService";
import { userService } from "./../../Profile/userService";
import { Role } from "./../../../Common/Auth/authTypes";
import FormSelect from "../../../Common/FormSelect";
import { FormSelectConfig } from "./../../../Common/FormSelect";
import { Link } from "react-router-dom";
import LoadingIndicator from "../../../Common/LoadingIndicator";

interface RegisterProps {
  className?: string;
}

export default function Register(props: RegisterProps) {
  const [params, setParams] = useState({
    name: "",
    surname: "",
    email: "",
    password: "",
    passwordConfirmation: "",
    role: "",
  });
  const placeholderRole: Role = { id: -1, name: "Select an account type" };

  const auth = useAuth();
  const [validationErrors, setValidationErrors] = useState<ValidationErrors>();
  const [availableRoles, setAvailableRoles] = useState<Role[]>([placeholderRole]);
  const [loadingPromise, setLoadingPromise] = useState<Promise<any>>();

  useEffect(() => {
    setLoadingPromise(
      userService.getAvailableRoles().then((response) => setAvailableRoles([placeholderRole, ...response.data]))
    );
  }, []);

  const onSubmit = (e: React.MouseEvent<any, MouseEvent>) => {
    const role = availableRoles.find((r) => r.name === params.role);
    e.preventDefault();
    registerService
      .register({
        ...params,
        roleId: role ? role.id : 0,
      })
      .then(undefined, (error) => {
        setValidationErrors(error.response.data);
      });
  };

  const onChange = (name: string, value: string) => {
    setParams({ ...params, [name]: value });
  };

  const inputConfig: FormInputConfig = {
    onChange,
    validationErrors,
  };

  const selectConfig: FormSelectConfig = {
    onChange,
    validationErrors,
  };

  return auth.currentUser ? (
    <Redirect to={routes.Home} />
  ) : (
    <LoadingIndicator promise={loadingPromise}>
      <div className={props.className}>
        <div className="ui-login-card shadow">
          <CardHeader>
            <h3 className="text-white">Sign up</h3>
          </CardHeader>
          <div className="ui-login-card-body">
            <Form>
              <FormInput className="flex-fill" config={inputConfig} type="text" name="name" displayName="Name*" />
              <FormInput className="flex-fill" config={inputConfig} type="text" name="surname" displayName="Surname*" />
              <FormInput className="flex-fill" config={inputConfig} type="text" name="email" displayName="Email*" />
              <FormInput
                className="flex-fill"
                config={inputConfig}
                type="password"
                name="password"
                displayName="Password*"
              />
              <FormInput
                className="flex-fill"
                config={inputConfig}
                type="password"
                name="passwordConfirmation"
                displayName="Password Confirmation*"
              />
              <FormSelect
                className="flex-fill"
                options={availableRoles.map((r) => r.name)}
                config={selectConfig}
                name="role"
                validationName="roleId"
                displayName="Account Type*"
              />
              <FormGroup>
                <Button color="primary" block={true} type="submit" onClick={onSubmit}>
                  Sign up
                </Button>
              </FormGroup>
            </Form>
          </div>
          <CardFooter>
            <small className="text-white">
              Already have an account? <Link to={routes.Login}>Click here to sign in</Link>
            </small>
          </CardFooter>
        </div>
      </div>
    </LoadingIndicator>
  );
}
