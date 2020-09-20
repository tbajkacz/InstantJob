import React, { useState, useEffect } from "react";
import { Modal, ModalBody } from "reactstrap";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faSpinner } from "@fortawesome/free-solid-svg-icons";
import { combineClasses } from "./componentUtility";

interface LoadingIndicatorProps {
  children?: JSX.Element | JSX.Element[];
  promise: Promise<any> | undefined;
  asModal?: boolean;
  inline?: boolean;
  size?: "small" | "medium" | "large";
}

export default function LoadingIndicator(props: LoadingIndicatorProps) {
  const [isCompleted, setIsCompleted] = useState(false);
  const [isError, setIsError] = useState(false);

  useEffect(() => {
    setIsCompleted(false);
    setIsError(false);
  }, [props.promise]);

  const getSize = () => {
    switch (props.size) {
      case "small":
        return "1x";
      case "large":
        return "4x";
      case "medium":
      default:
        return "2x";
    }
  };

  const renderLoadingIndicator = () => {
    const icon = <FontAwesomeIcon icon={faSpinner} spin={true} color="white" size={getSize()} />;
    const loadingIndicator = props.inline ? icon : <div className="d-flex justify-content-center">{icon}</div>;
    if (props.asModal) {
      return (
        <Modal className="ui-bg-transparent" isOpen={!isCompleted}>
          <ModalBody>{loadingIndicator}</ModalBody>
        </Modal>
      );
    }
    return loadingIndicator;
  };

  const renderErrorIndicator = () => {
    const errorMessage = "An unexpected error has occured";
    const errorIndicator = (
      <div className={combineClasses("d-flex justify-content-center text-white", props.inline ? "inline" : "")}>
        {errorMessage}
      </div>
    );
    if (props.asModal) {
      return (
        <Modal className="ui-bg-transparent" isOpen={!isCompleted}>
          <ModalBody>{errorIndicator}</ModalBody>
        </Modal>
      );
    }
    return errorIndicator;
  };

  if (props.promise) {
    props.promise.then(
      () => {
        setIsCompleted(true);
      },
      (error) => {
        setIsCompleted(true);
        if (error.response.status === 500) {
          setIsError(true);
        }
      }
    );
    return <>{isCompleted ? (isError ? renderErrorIndicator() : props.children) : renderLoadingIndicator()}</>;
  }
  return <>{props.children}</>;
}
