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
import { JobCategory } from "./jobsTypes";

interface TopFilterPanelProps {
  className?: string;
  filtersChanged: () => void;
}

interface TopFilterPanelPropsState {
  nameSearch: string;
  categorySearch: string;
}

export default function TopFilterPanel(props: TopFilterPanelProps) {
  const placeholderCategory = { id: "", name: "All categories" };

  const [categories, setCategories] = useState<JobCategory[]>([placeholderCategory]);

  const [state, setState] = useState<TopFilterPanelPropsState>({ nameSearch: "", categorySearch: "" });
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
  }, []);

  const onFiltersChanged = () => {
    let category = categories.find((c) => c.name === state.categorySearch);
    let categoryId = category ? category.id : "";

    let query: JobsListQuery = {
      search: state.nameSearch,
      categoryId,
    };

    history.push(`${routes.Jobs}${buildQuery(query)}`);
    props.filtersChanged();
  };

  const tryGetDefaultCategoryValue = () => {
    if (queryParams && queryParams.categoryId) {
      return categories.find((c) => c.id === queryParams.categoryId)?.name;
    }
    return undefined;
  };

  return (
    <Form>
      <div className={props.className}>
        <div className="row">
          <div className="col-sm-5">
            <FormInput name="nameSearch" displayName="Search" config={inputConfig} />
          </div>
          <div className="col-sm-5">
            <FormSelect
              name="categorySearch"
              displayName="Category"
              config={selectConfig}
              options={categories.map((c) => c.name)}
              defaultValue={tryGetDefaultCategoryValue()}
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
