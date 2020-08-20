import React from "react";
import { Button } from "reactstrap";

interface HomeProps {
  className?: string;
}

export default function Home(props: HomeProps) {
  return <Button className="btn btn-primary">Home</Button>;
}
