import React, { useEffect, useState } from "react";
import { useParams } from "react-router";
import { useAuth } from "../../Common/Auth/authContext";
import { combineClasses } from "../../Common/componentUtility";
import { formatDateShort } from "../../Common/dateFormatter";
import LoadingIndicator from "../../Common/LoadingIndicator";
import roles from "../../Common/roles";
import ContractorProfileInfo from "./ContractorProfileInfo";
import MandatorProfileInfo from "./MandatorProfileInfo";
import { userService } from "./userService";
import { UserProfileInfo } from "./userTypes";

interface UserProfileProps {
  className?: string;
}

interface UserProfileRouteParams {
  userId: string;
}

export default function UserProfile(props: UserProfileProps) {
  const [loadingPromise, setLoadingPromise] = useState<Promise<any>>();
  const [userProfileInfo, setUserProfileInfo] = useState<UserProfileInfo>();

  const params = useParams<UserProfileRouteParams>();

  const auth = useAuth();

  useEffect(() => {
    setLoadingPromise(
      userService.getUserById({ userId: params.userId }).then((r) => {
        setUserProfileInfo(r.data);
      })
    );
  }, [params]);

  const renderRoleDependentSection = () => {
    if (userProfileInfo?.role?.name) {
      switch (userProfileInfo.role.name) {
        case roles.contractor:
          return <ContractorProfileInfo userId={params.userId} />;
        case roles.mandator:
          return <MandatorProfileInfo userId={params.userId} />;
      }
    }
  };

  if (!userProfileInfo) {
    return null;
  }

  return (
    <LoadingIndicator promise={loadingPromise}>
      <div className={combineClasses(props.className, "ui-flex-container")}>
        <div className="ui-wrapper col-sm-9">
          <div className="ui-header row">
            <div className="col-sm-1">
              <img
                src={
                  userProfileInfo.picture
                    ? `data:image/jpeg;base64,${userProfileInfo.picture}`
                    : "https://alaakriedy.net/wp-content/uploads/2016/05/placeholder-1100x1100.png"
                }
                height="100px"
                width="100px"
              />
            </div>
            <div className="ml-4">
              <h2>{`${userProfileInfo.name} ${userProfileInfo.surname}`}</h2>
              <h6>{`${userProfileInfo.email}`}</h6>
              <small>{`${userProfileInfo.role.name} since ${formatDateShort(userProfileInfo.creationDate)}`}</small>
            </div>
          </div>
          <div className="ui-content">{renderRoleDependentSection()}</div>
        </div>
      </div>
    </LoadingIndicator>
  );
}
