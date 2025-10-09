import { Product } from '../../model/product'


export interface ProductState {
  products: Product[];
  loading: boolean;
  error: string | null;
}