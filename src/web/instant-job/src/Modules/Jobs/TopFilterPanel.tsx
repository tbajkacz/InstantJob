import React, { useEffect, useState } from "react";
import { useHistory } from "react-router";
import { Button, Form } from "reactstrap";
import { buildQuery, useQueryParams } from "../../Common/buildQuery";
import { combineClasses } from "../../Common/componentUtility";
import { FormInput, FormInputConfig } from "../../Common/FormInput";
import FormSelect, { FormSelectConfig } from "../../Common/FormSelect";
import HorizontalFormButton from "../../Common/HorizontalFormButton";
import routes from "../../Common/routes";
import { categoriesService } from "../Categories/categoriesService";
import { JobsListQuery } from "./JobsList";
import { JobCategory, JobDifficulty, JobStatus } from "./jobsTypes";
import { jobsService } from "./jobsService";
import useEffectAsync from "./../../Common/useEffectAsync";
import JobModal from "./JobModal";

interface TopFilterPanelProps {
  className?: string;
}

interface TopFilterPanelPropsState {
  nameSearch: string;
  categorySearch: string;
  difficultySearch: string;
  mandatorId?: string;
  contractorId?: string;
  status?: string;
  includeExpired?: boolean;
}

export default function TopFilterPanel(props: TopFilterPanelProps) {
  const placeholderCategory = { id: "", name: "All categories" };
  const placeholderDifficulty = { id: 0, name: "All difficulties" };
  const placeholderJobStatus: JobStatus = {
    id: 1,
    name: "Available",
    isAssigned: false,
    isAvailable: true,
    isCanceled: false,
    isCompleted: false,
    isInProgress: false,
  };
  const initialState: TopFilterPanelPropsState = {
    nameSearch: "",
    categorySearch: "",
    difficultySearch: "",
    mandatorId: "",
    contractorId: "",
    status: "",
    includeExpired: undefined,
  };

  const [categories, setCategories] = useState<JobCategory[]>([placeholderCategory]);
  const [difficulties, setDifficulties] = useState<JobDifficulty[]>([placeholderDifficulty]);
  const [statuses, setStatuses] = useState<JobStatus[]>([placeholderJobStatus]);
  const [includeExpiredOptions, setIncludeExpiredOptions] = useState([{ name: "false" }, { name: "true" }]);

  const [state, setState] = useState<TopFilterPanelPropsState>(initialState);
  const history = useHistory();
  const queryParams = useQueryParams<JobsListQuery>();

  const onChange = (name: string, value: string) => {
    setState({ ...state, [name]: value });
  };

  const inputConfig: FormInputConfig = {
    onChange,
  };

  const selectConfig: FormSelectConfig = {
    onChange,
  };
  useEffect(() => {
    categoriesService.GetCategories().then((r) => {
      setCategories([placeholderCategory, ...r.data]);
    });
    jobsService.GetJobDifficulties().then((r) => {
      setDifficulties([placeholderDifficulty, ...r.data]);
    });
    jobsService.GetJobStatuses().then((r) => setStatuses([...r.data]));
  }, []);

  useEffect(() => {
    if (queryParams) {
      let categoryName = categories.find((c) => c.id === queryParams?.categoryId)?.name;
      let difficultyName = difficulties.find((d) => d.id == queryParams?.difficultyId)?.name;

      setState({
        ...queryParams,
        status: queryParams.status ? queryParams.status : initialState.status,
        nameSearch: queryParams.searchString ? queryParams.searchString : initialState.nameSearch,
        categorySearch: categoryName ? categoryName : initialState.categorySearch,
        difficultySearch: difficultyName ? difficultyName : initialState.difficultySearch,
      });
    }
  }, [difficulties, categories]);

  const onFiltersChanged = () => {
    let category = categories.find((c) => c.name === state.categorySearch);
    let categoryId = category ? category.id : undefined;
    let difficulty = difficulties.find((d) => d.name === state.difficultySearch);
    let difficultyId = difficulty && difficulty.id !== 0 ? difficulty.id : undefined;

    let query: JobsListQuery = {
      searchString: state.nameSearch,
      categoryId,
      difficultyId: difficultyId,
      contractorId: state.contractorId,
      mandatorId: state.mandatorId,
      status: state.status,
      includeExpired: state.includeExpired,
    };

    history.push(`${routes.Jobs}${buildQuery(query)}`);
  };

  const onClearFilters = () => {
    history.push(
      `${routes.Jobs}${buildQuery({
        contractorId: state.contractorId,
        mandatorId: state.mandatorId,
        includeExpired: false,
      })}`
    );
  };

  const tryGetDefaultCategoryValue = () => {
    if (queryParams && queryParams.categoryId) {
      return categories.find((c) => c.id === queryParams.categoryId)?.name;
    }
    return undefined;
  };

  const tryGetDefaultDifficultyValue = () => {
    if (queryParams && queryParams.difficultyId) {
      // TODO === for some reason returns false for each comparison???
      return difficulties.find((d) => d.id == queryParams.difficultyId)?.name;
    }
    return undefined;
  };

  const tryGetDefaultStatusValue = () => {
    if (queryParams && queryParams.status) {
      return statuses.find((s) => s.name === queryParams.status)?.name;
    }
    return placeholderJobStatus.name;
  };

  const tryGetIncludeExpiredDefaultValue = () => {
    if (queryParams && queryParams.includeExpired) {
      return includeExpiredOptions.find((i) => i.name === queryParams.includeExpired!.toString())?.name;
    }
    return undefined;
  };

  return (
    <>
      <Form>
        <div className={props.className}>
          <div className="row">
            <div className="col-md-5">
              <FormInput
                defaultValue={queryParams?.searchString}
                name="nameSearch"
                displayName="Search"
                config={inputConfig}
              />
            </div>

            <div className="col-md-4">
              <FormSelect
                name="status"
                displayName="Status"
                config={selectConfig}
                options={statuses.map((c) => c.name)}
                defaultValue={tryGetDefaultStatusValue()}
              />
            </div>
            <div className="col-md-2">
              <FormSelect
                name="includeExpired"
                displayName="Include expired"
                config={selectConfig}
                options={includeExpiredOptions.map((c) => c.name)}
                defaultValue={tryGetIncludeExpiredDefaultValue()}
              />
            </div>
          </div>
          <div className="row">
            <div className="col-md-5">
              <FormSelect
                name="categorySearch"
                displayName="Category"
                config={selectConfig}
                options={categories.map((c) => c.name)}
                defaultValue={tryGetDefaultCategoryValue()}
              />
            </div>
            <div className="col-md-5">
              <FormSelect
                name="difficultySearch"
                displayName="Difficulty"
                config={selectConfig}
                options={difficulties.map((c) => c.name)}
                defaultValue={tryGetDefaultDifficultyValue()}
              />
            </div>
            <div className="col-md-2 btn-group">
              <HorizontalFormButton className="mr-2" color="primary" onClick={onFiltersChanged}>
                Search
              </HorizontalFormButton>
              <HorizontalFormButton onClick={onClearFilters} color="secondary">
                Reset
              </HorizontalFormButton>
            </div>
          </div>
        </div>
      </Form>
    </>
  );
}
