import React from "react";
import ValidationErrors from "./validationErrors";
import { FormGroup } from "reactstrap";
import { combineClasses } from "./componentUtility";

export interface FormSelectConfig {
  onChange: (name: string, value: string) => void;
  isDisabled?: (name: string) => boolean;
  isHidden?: (name: string) => boolean;
  validationErrors?: ValidationErrors;
}

interface FormSelectProps {
  options: string[];
  name: string;
  className?: string;
  config: FormSelectConfig;
}

export default function FormSelect(props: FormSelectProps) {
  const isHidden = () => props.config.isHidden && props.config.isHidden(props.name);
  const isDisabled = () => props.config.isDisabled && props.config.isDisabled(props.name);

  const renderError = () => {
    if (props.config.validationErrors && !isHidden() && !isDisabled()) {
      let propKey = Object.keys(props.config.validationErrors).find((k) => k.toLowerCase() == props.name.toLowerCase());
      if (propKey) {
        return props.config.validationErrors[propKey][0];
      }
    }
  };
  return (
    <FormGroup>
      <label className="flex-row ui-input-label" hidden={isHidden()}>
        <small>{props.name.charAt(0).toUpperCase() + props.name.slice(1)}</small>
      </label>
      <div>
        <select className={combineClasses("ui-select-dark", props.className)}>
          {props.options.map((o) => (
            <option>{o}</option>
          ))}
        </select>
      </div>
    </FormGroup>
  );
}
