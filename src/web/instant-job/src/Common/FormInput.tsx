import React, { useState } from "react";
import { FieldError } from "react-hook-form/dist/types";
import { FormGroup } from "reactstrap";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { IconProp } from "@fortawesome/fontawesome-svg-core";
import { combineClasses } from "./componentUtility";
import ValidationErrors from "./validationErrors";

export interface FormInputConfig {
  onChange: (name: string, value: string) => void;
  isDisabled?: (name: string) => boolean;
  isHidden?: (name: string) => boolean;
  validationErrors?: ValidationErrors;
}

interface FormInputProps {
  className?: string;
  config: FormInputConfig;
  name: string;
  displayName: string;
  type?: "text" | "number" | "password";
  defaultValue?: string | number;
  errorMsg?: string;
  icon?: IconProp;
  required?: boolean;
  inputRef?: (instance: HTMLInputElement | null) => void;
}

export function FormInput(props: FormInputProps) {
  const [value, setValue] = useState("");

  const isHidden = () => props.config.isHidden && props.config.isHidden(props.name);
  const isDisabled = () => props.config.isDisabled && props.config.isDisabled(props.name);

  const renderError = () => {
    if (props.config.validationErrors && !isHidden() && !isDisabled()) {
      let propKey = Object.keys(props.config.validationErrors).find(
        (k) => k.toLowerCase() === props.name.toLowerCase()
      );
      if (propKey) {
        return props.config.validationErrors[propKey][0];
      }
    }
  };

  return (
    <FormGroup className={combineClasses(props.className, isHidden() ? "mb-0" : undefined)}>
      <label className="flex-row ui-input-label" hidden={isHidden()}>
        <small>
          {props.displayName.charAt(0).toUpperCase() + props.displayName.slice(1) + (props.required ? "*" : "")}
        </small>
      </label>
      <div className="d-flex">
        {props.icon ? (
          <span className="ui-input-icon">
            <FontAwesomeIcon icon={props.icon} />
          </span>
        ) : null}
        <input
          className={combineClasses(
            props.config.validationErrors && props.config.validationErrors[props.name]
              ? "ui-input-dark is-invalid"
              : "ui-input-dark",
            props.className
          )}
          name={props.name}
          type={props.type}
          placeholder={props.displayName}
          onChange={(e) => {
            setValue(e.currentTarget.value);
            props.config.onChange(props.name, e.currentTarget.value);
          }}
          readOnly={isDisabled()}
          hidden={isHidden()}
          defaultValue={props.defaultValue}
          ref={isHidden() || isDisabled() ? undefined : props.inputRef}
        />
      </div>
      <small className="text-danger">{renderError()}</small>
    </FormGroup>
  );
}
