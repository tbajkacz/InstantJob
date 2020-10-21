import React, { useEffect, useState } from "react";
import { FormInput, FormInputConfig } from "../../Common/FormInput";
import { UserBasicInfo } from "./userTypes";
import { userService } from "./userService";
import FindProfileListItem from "./FindProfileListItem";
import { Button, Modal, ModalBody, ModalFooter, ModalHeader } from "reactstrap";

interface FindProfileModalProps {
  isOpen: boolean;
  toggle: () => void;
}

export default function FindProfileModal(props: FindProfileModalProps) {
  const [search, setSearch] = useState<string>();
  const [matchedUsers, setMatchedUsers] = useState<UserBasicInfo[]>();

  const updateUsersList = () => {
    if (search) {
      userService.findByName({ search }).then((r) => setMatchedUsers(r.data.users));
    }
  };

  const onChange = (name: string, value: string) => {
    setSearch(value);
  };

  useEffect(() => {
    setSearch("");
    setMatchedUsers([]);
  }, [props.isOpen]);

  //executes only if 500ms have passed since the latest search change
  useEffect(() => {
    const timeout = setTimeout(() => {
      updateUsersList();
    }, 500);
    return () => {
      clearTimeout(timeout);
    };
  }, [search]);

  const config: FormInputConfig = {
    onChange,
  };

  const renderList = () => {
    if (!matchedUsers) {
      return <p className="text-white">Found users will be displayed here</p>;
    } else if (matchedUsers.length === 0) {
      return <p className="text-white">No users matching the search criteria were found</p>;
    } else {
      return (
        <ul className="ui-list-dark col-sm-12">
          {matchedUsers?.map((u) => (
            <FindProfileListItem key={u.id} userInfo={u} onClick={props.toggle} />
          ))}
        </ul>
      );
    }
  };

  return (
    <Modal isOpen={props.isOpen} toggle={props.toggle}>
      <ModalHeader>User search</ModalHeader>
      <ModalBody>
        <div className="ui-header">
          <FormInput config={config} name="search" displayName="Type a name or surname to search for a specific user" />
        </div>
        <div className="ui-content">{renderList()}</div>
      </ModalBody>
      <ModalFooter>
        <Button color="secondary" onClick={props.toggle}>
          Close
        </Button>
      </ModalFooter>
    </Modal>
  );
}
