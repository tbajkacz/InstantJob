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
  displayName: string;
  defaultValue?: string;
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

  const onSelectChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
    console.log(e.currentTarget.id);
    props.config.onChange(props.name, e.currentTarget.value);
  };
  return (
    <FormGroup>
      <label className="flex-row ui-input-label" hidden={isHidden()}>
        <small>{props.displayName.charAt(0).toUpperCase() + props.displayName.slice(1)}</small>
      </label>
      <div>
        <select className={combineClasses("ui-select-dark", props.className)} onChange={onSelectChange}>
          {props.options.map((o) => (
            <option id={o} selected={o === props.defaultValue}>
              {o}
            </option>
          ))}
        </select>
      </div>
      <small className="text-danger">{renderError()}</small>
    </FormGroup>
  );
}
