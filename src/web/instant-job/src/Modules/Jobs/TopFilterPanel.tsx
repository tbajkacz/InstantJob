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
import { JobCategory, JobDifficulty } from "./jobsTypes";
import { jobsService } from "./jobsService";

interface TopFilterPanelProps {
  className?: string;
}

interface TopFilterPanelPropsState {
  nameSearch: string;
  categorySearch: string;
  difficultySearch: string;
}

export default function TopFilterPanel(props: TopFilterPanelProps) {
  const placeholderCategory = { id: "", name: "All categories" };
  const placeholderDifficulty = { id: 0, name: "All difficulties" };

  const [categories, setCategories] = useState<JobCategory[]>([placeholderCategory]);
  const [difficulties, setDifficulties] = useState<JobDifficulty[]>([placeholderDifficulty]);

  const [state, setState] = useState<TopFilterPanelPropsState>({
    nameSearch: "",
    categorySearch: "",
    difficultySearch: "",
  });
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
  }, []);

  const onFiltersChanged = () => {
    let category = categories.find((c) => c.name === state.categorySearch);
    let categoryId = category ? category.id : undefined;
    let difficulty = difficulties.find((d) => d.name === state.difficultySearch);
    let difficultyId = difficulty && difficulty.id !== 0 ? difficulty.id : undefined;

    let query: JobsListQuery = {
      search: state.nameSearch,
      categoryId,
      difficultyId: difficultyId,
    };

    history.push(`${routes.Jobs}${buildQuery(query)}`);
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

  return (
    <Form>
      <div className={props.className}>
        <div className="row">
          <div className="col-sm-4">
            <FormInput defaultValue={queryParams?.search} name="nameSearch" displayName="Search" config={inputConfig} />
          </div>
          <div className="col-sm-3">
            <FormSelect
              name="categorySearch"
              displayName="Category"
              config={selectConfig}
              options={categories.map((c) => c.name)}
              defaultValue={tryGetDefaultCategoryValue()}
            />
          </div>
          <div className="col-sm-3">
            <FormSelect
              name="difficultySearch"
              displayName="Difficulty"
              config={selectConfig}
              options={difficulties.map((c) => c.name)}
              defaultValue={tryGetDefaultDifficultyValue()}
            />
          </div>
          <div className="col-sm-2">
            <HorizontalFormButton onClick={onFiltersChanged}>Search</HorizontalFormButton>
          </div>
        </div>
      </div>
    </Form>
  );
}
