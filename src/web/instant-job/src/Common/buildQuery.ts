import { useLocation } from "react-router";
export interface QueryParam {
  name: string;
  value: string;
}

export function buildQuery(param: { [key: string]: any }) {
  let query = "?";
  Object.keys(param).forEach((k) => {
    if (param[k] !== undefined && param[k] !== "") {
      if (query.length > 1) {
        query += "&";
      }
      query += `${k}=${param[k]}`;
    }
  });
  return query === "?" ? "" : query;
}

export function useQueryParams<T>() {
  const location = useLocation();

  if (!location.search) {
    return undefined;
  }
  var search = location.search.substring(1);
  return JSON.parse(
    '{"' + decodeURI(search).replace(/"/g, '\\"').replace(/&/g, '","').replace(/=/g, '":"') + '"}'
  ) as T;
}
