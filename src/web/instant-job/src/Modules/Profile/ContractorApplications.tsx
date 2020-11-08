import React, { useEffect, useState } from "react";
import LoadingIndicator from "../../Common/LoadingIndicator";
import ContractorApplicationListItem from "./ContractorApplicationListItem";
import { userService } from "./userService";
import { ContractorApplication } from "./userTypes";

export default function ContractorApplications() {
  const [loadingPromise, setLoadingPromise] = useState<Promise<any>>();
  const [contractorApplications, setContractorApplications] = useState<ContractorApplication[]>();

  const refreshApplications = () => {
    return userService.getContractorApplications().then((r) => setContractorApplications(r.data));
  };

  useEffect(() => {
    setLoadingPromise(refreshApplications());
  }, []);

  const onAction = () => {
    refreshApplications();
  };

  if (!contractorApplications) {
    return <LoadingIndicator promise={loadingPromise} />;
  }

  return (
    <div className="ui-flex-container">
      <div className="ui-wrapper col-sm-9">
        <h3 className="ui-header">Your applications</h3>
        <table className="ui-table-dark">
          <thead>
            <tr>
              <th scope="col" className="col-sm-3">
                Job id
              </th>
              <th scope="col" className="col-sm-6">
                Job name
              </th>
              <th scope="col" className="col-sm-2">
                Application date
              </th>
            </tr>
          </thead>
          <tbody>
            {contractorApplications.map((a) => (
              <ContractorApplicationListItem application={a} />
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
}
