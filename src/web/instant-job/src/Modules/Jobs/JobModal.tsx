import React, { useEffect, useState } from "react";
import { Button, Modal, ModalBody, ModalFooter, ModalHeader } from "reactstrap";
import { FormInput, FormInputConfig } from "../../Common/FormInput";
import FormSelect, { FormSelectConfig } from "../../Common/FormSelect";
import ValidationErrors from "../../Common/validationErrors";
import { jobsService } from "./jobsService";
import { JobCategory, JobDetails, JobDifficulty, PostJobCommand, UpdateJobInformationCommand } from "./jobsTypes";
import "../../styles/DatepickerVariables.scss";
import FormDatePicker from "../../Common/FormDatePicker";

interface JobModalProps {
  type: "add" | "edit";
  jobDetails?: JobDetails;
  isOpen: boolean;
  toggle: () => void;
  onSuccessClosed: (newJobId: string) => void;
}

interface JobModalState {
  title: string;
  description: string;
  price: number | undefined;
  deadline: Date;
  difficultyName: string;
  categoryName: string;
}

export default function JobModal(props: JobModalProps) {
  const placeholderCategory = { id: "", name: "---" };
  const placeholderDifficulty = { id: 0, name: "---" };

  const getInitialState = (): JobModalState => {
    return {
      title: props.jobDetails?.title ? props.jobDetails.title : "",
      description: props.jobDetails?.description ? props.jobDetails.description : "",
      price: props.jobDetails?.price ? props.jobDetails.price : undefined,
      deadline: props.jobDetails?.deadline ? props.jobDetails?.deadline : new Date(),
      difficultyName: props.jobDetails?.difficulty ? props.jobDetails.difficulty.name : "",
      categoryName: props.jobDetails?.category ? props.jobDetails.category.name : "",
    };
  };
  const initialState: JobModalState = getInitialState();

  const [difficulties, setDifficulties] = useState<JobDifficulty[]>([placeholderDifficulty]);
  const [categories, setCategories] = useState<JobCategory[]>([placeholderCategory]);
  const [validationErrors, setValidationErrors] = useState<ValidationErrors>();

  const [state, setState] = useState<JobModalState>(initialState);

  useEffect(() => {
    jobsService.GetJobDifficulties().then((r) => setDifficulties([placeholderDifficulty, ...r.data]));
    jobsService.GetJobCategories().then((r) => setCategories([placeholderCategory, ...r.data]));
    setState(getInitialState());
    setValidationErrors(undefined);
  }, [props.isOpen]);

  const onChange = (name: string, value: any) => {
    console.log(typeof value);
    if (typeof value === "string") {
      setState({ ...state, [name]: value });
    } else if (typeof value === "number") {
      console.log(value as number);
      setState({ ...state, [name]: value as number });
    } else if (typeof value === "object" && value instanceof Date) {
      setState({ ...state, [name]: value as Date });
    }
  };

  const inputConfig: FormInputConfig = {
    onChange,
    validationErrors,
  };

  const selectConfig: FormSelectConfig = {
    onChange,
    validationErrors,
    isHidden: (name: string) => name === "categoryName" && props.type === "edit",
  };

  const onPostJob = async () => {
    const difficulty = difficulties.find((d) => d.name === state.difficultyName);
    const category = categories.find((c) => c.name === state.categoryName);

    const postJobCommand: PostJobCommand = {
      title: state.title,
      description: state.description,
      price: state.price,
      deadline: state.deadline,
      difficultyId: difficulty ? difficulty.id : 0,
      categoryId: category ? category.id : "",
    };

    await jobsService.PostJob(postJobCommand).then(
      (r) => {
        props.onSuccessClosed(r.data.id);
        props.toggle();
      },
      (error) => {
        setValidationErrors(error.response.data);
      }
    );
  };
  const onEditJob = async () => {
    const difficulty = difficulties.find((d) => d.name === state.difficultyName);

    const updateJobCommand: UpdateJobInformationCommand = {
      jobId: props.jobDetails!.id,
      title: state.title,
      description: state.description,
      price: state.price,
      deadline: state.deadline,
      difficultyId: difficulty ? difficulty.id : 0,
    };

    await jobsService.UpdateJobInformation(updateJobCommand).then(
      (r) => {
        props.onSuccessClosed(r.data.id);
        props.toggle();
      },
      (error) => {
        setValidationErrors(error.response.data);
      }
    );
  };

  const onSubmit = async () => {
    switch (props.type) {
      case "add":
        await onPostJob();
        break;
      case "edit":
        await onEditJob();
        break;
    }
  };

  return (
    <Modal isOpen={props.isOpen} toggle={props.toggle}>
      <ModalHeader>{`${props.type[0].toUpperCase() + props.type.substr(1)} job offer`}</ModalHeader>
      <ModalBody>
        <FormInput config={inputConfig} name="title" displayName="Title" required defaultValue={state.title} />
        <FormInput config={inputConfig} name="description" displayName="Description" defaultValue={state.description} />
        <FormInput config={inputConfig} name="price" type="number" displayName="Price" defaultValue={state.price} />
        <FormDatePicker
          validationErrors={validationErrors}
          validationName="Deadline"
          displayName="Deadline"
          onChange={(date) => onChange("deadline", date)}
          required
          defaultValue={state.deadline}
        />
        <FormSelect
          config={selectConfig}
          name="difficultyName"
          validationName="difficultyId"
          displayName="Difficulty"
          options={difficulties.map((d) => d.name)}
          required
          defaultValue={state.difficultyName}
        />
        <FormSelect
          config={selectConfig}
          name="categoryName"
          validationName="categoryId"
          displayName="Category"
          options={categories.map((c) => c.name)}
          required
          defaultValue={state.categoryName}
        />
      </ModalBody>
      <ModalFooter>
        <Button color="primary" onClick={onSubmit}>
          Accept
        </Button>
        <Button color="secondary" onClick={props.toggle}>
          Cancel
        </Button>
      </ModalFooter>
    </Modal>
  );
}
