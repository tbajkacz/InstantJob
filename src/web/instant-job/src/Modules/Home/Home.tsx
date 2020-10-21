import React from "react";
import { Button } from "reactstrap";

interface HomeProps {
  className?: string;
}

export default function Home(props: HomeProps) {
  return (
    <ul className="text-white">
      <li>TODO</li>
      <li>Home view</li>
      <li>Grayed job if expired</li>
      <li>Navbar links to your jobs both for mandator and contractor</li>
      <li>Your applications tab</li>
      <li>Add job view</li>
      <li>Registration confirmation</li>
    </ul>
  );
}
