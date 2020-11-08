import { DatePicker } from "@y0c/react-datepicker";
import dayjs from "dayjs";
import React from "react";
import ValidationErrors from "./validationErrors";

interface FormDatePickerProps {
  onChange: (date: Date) => void;
  displayName: string;
  validationName: string;
  validationErrors?: ValidationErrors;
  required?: boolean;
  defaultValue: Date;
}

export default function FormDatePicker(props: FormDatePickerProps) {
  const onChange = (date: any, rawValue: string) => {
    let newDate = new Date(rawValue);
    newDate.setHours(23, 59, 59);
    props.onChange(newDate);
  };

  const renderError = () => {
    if (props.validationErrors) {
      let propKey = Object.keys(props.validationErrors).find(
        (k) => k.toLowerCase() === props.validationName.toLowerCase()
      );
      if (propKey) {
        return props.validationErrors[propKey][0];
      }
    }
  };

  return (
    <div className="form-group">
      <label className="flex-row ui-input-label">
        <small>{props.displayName + (props.required ? "*" : "")}</small>
      </label>
      <DatePicker onChange={onChange} initialDate={dayjs(props.defaultValue)} />
      <small className="text-danger">{renderError()}</small>
    </div>
  );
}
