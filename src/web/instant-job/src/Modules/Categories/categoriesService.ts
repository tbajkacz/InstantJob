import axios from "axios";
import { JobCategory } from "../Jobs/jobsTypes";

class CategoriesService {
  GetCategories() {
    return axios.get<JobCategory[]>(`/api/categories`);
  }
}

export const categoriesService = new CategoriesService();
