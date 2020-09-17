import React from "react";
import { Button } from "reactstrap";

interface NavbarButtonProps {
  children?: React.ReactNode;
  onClick?: () => void;
}

export default function NavbarButton(props: NavbarButtonProps) {
  return (
    <Button size="sm" color="secondary" onClick={props.onClick}>
      {props.children}
    </Button>
  );
}
