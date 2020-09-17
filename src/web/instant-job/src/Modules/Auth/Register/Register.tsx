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

interface RegisterProps {
  className?: string;
}

export default function Register(props: RegisterProps) {
  const [params, setParams] = useState<RegisterParams>({
    name: "",
    surname: "",
    email: "",
    password: "",
    passwordConfirmation: "",
    roleId: 0,
  });

  const auth = useAuth();
  const [validationErrors, setValidationErrors] = useState<ValidationErrors>();
  const [availableRoles, setAvailableRoles] = useState<Role[]>([]);

  useEffect(() => {
    userService.getAvailableRoles().then((response) => setAvailableRoles(response.data));
  }, []);

  const onSubmit = (e: React.MouseEvent<any, MouseEvent>) => {
    e.preventDefault();
    registerService.register(params).then(undefined, (error) => {
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
    <div className={props.className}>
      <div className="ui-login-card shadow">
        <CardHeader>
          <h3 className="text-white">Sign up</h3>
        </CardHeader>
        <div className="ui-login-card-body">
          <Form>
            <FormInput className="flex-fill" config={inputConfig} type="text" name="name" />
            <FormInput className="flex-fill" config={inputConfig} type="text" name="surname" />
            <FormInput className="flex-fill" config={inputConfig} type="text" name="email" />
            <FormInput className="flex-fill" config={inputConfig} type="password" name="password" />
            <FormInput className="flex-fill" config={inputConfig} type="password" name="passwordConfirmation" />
            <FormSelect
              className="flex-fill"
              options={availableRoles.map((r) => r.name)}
              config={selectConfig}
              name="role"
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
  );
}
