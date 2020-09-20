import React from "react";
import { Button } from "reactstrap";

interface HorizontalFormButtonProps {
  className?: string;
  children?: string;
  onClick?: () => void;
}

export default function HorizontalFormButton(props: HorizontalFormButtonProps) {
  const onClick = (e: React.MouseEvent<HTMLInputElement>) => {
    e.preventDefault();
    if (props.onClick) {
      props.onClick();
    }
  };

  return (
    <div className={props.className}>
      <div>
        <small style={{ visibility: "hidden" }}>.</small>
      </div>
      <Button onClick={onClick}>Search</Button>
    </div>
  );
}
