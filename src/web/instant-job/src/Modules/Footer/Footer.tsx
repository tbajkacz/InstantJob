import React from "react";
import { combineClasses } from "../../Common/componentUtility";

export interface FooterProps {
  className?: string;
}

export default React.memo(function Footer(props: FooterProps) {
  return (
    <footer className={combineClasses("ui-footer-wrapper-dark", props.className)}>
      <div className="container">
        <div className="row">
          <div className="col-sm-3">
            <div>Instant Job</div>
            <small>© 2020-2021</small>
          </div>
          <div className="col-sm-4"></div>
          <div className="col-sm-5"></div>
        </div>
      </div>
    </footer>
  );
});
