import React, { useEffect, useState } from "react";
import { Button, Modal, ModalBody, ModalFooter, ModalHeader } from "reactstrap";
import { FormInput, FormInputConfig } from "../../Common/FormInput";
import FormSelect, { FormSelectConfig } from "../../Common/FormSelect";
import ValidationErrors from "../../Common/validationErrors";
import { jobsService } from "./jobsService";
import { JobCategory, JobDetails, JobDifficulty, PostJobCommand } from "./jobsTypes";
import { DatePicker } from "@y0c/react-datepicker";
import "../../styles/DatepickerVariables.scss";
import FormDatePicker from "../../Common/FormDatePicker";

interface JobModalProps {
  type: "add" | "edit";
  jobDetails?: JobDetails;
  isOpen: boolean;
  toggle: () => void;
  onClosed: (newJobId: string) => void;
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
  const initialState: JobModalState = {
    title: "",
    description: "",
    price: undefined,
    deadline: new Date(),
    difficultyName: "",
    categoryName: "",
  };

  const [difficulties, setDifficulties] = useState<JobDifficulty[]>([placeholderDifficulty]);
  const [categories, setCategories] = useState<JobCategory[]>([placeholderCategory]);
  const [validationErrors, setValidationErrors] = useState<ValidationErrors>();

  const [state, setState] = useState<JobModalState>(initialState);

  useEffect(() => {
    jobsService.GetJobDifficulties().then((r) => setDifficulties([placeholderDifficulty, ...r.data]));
    jobsService.GetJobCategories().then((r) => setCategories([placeholderCategory, ...r.data]));
  }, []);

  const onChange = (name: string, value: any) => {
    console.log(typeof value);
    if (typeof value === "string") {
      setState({ ...state, [name]: value });
    } else if (typeof value === "number") {
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
  };

  const onSubmit = async () => {
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
        props.onClosed(r.data.id);
        props.toggle();
      },
      (error) => {
        setValidationErrors(error.response.data);
      }
    );
  };

  return (
    <Modal isOpen={props.isOpen} toggle={props.toggle}>
      <ModalHeader>{`${props.type[0].toUpperCase() + props.type.substr(1)} job offer`}</ModalHeader>
      <ModalBody>
        <FormInput config={inputConfig} name="title" displayName="Title" required />
        <FormInput config={inputConfig} name="description" displayName="Description" />
        <FormInput config={inputConfig} name="price" displayName="Price" />
        <FormDatePicker
          validationErrors={validationErrors}
          validationName="Deadline"
          displayName="Deadline"
          onChange={(date) => onChange("deadline", date)}
          required
        />
        <FormSelect
          config={selectConfig}
          name="difficultyName"
          validationName="difficultyId"
          displayName="Difficulty"
          options={difficulties.map((d) => d.name)}
          required
        />
        <FormSelect
          config={selectConfig}
          name="categoryName"
          validationName="categoryId"
          displayName="Category"
          options={categories.map((c) => c.name)}
          required
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
