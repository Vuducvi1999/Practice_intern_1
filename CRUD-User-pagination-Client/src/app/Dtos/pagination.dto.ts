import { readProduct } from './readProduct.dto';

export interface Pagination {
  index: number;
  totalPages: number;
  data: readProduct[];
}
