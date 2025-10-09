import {createReducer, on} from '@ngrx/store'
import { ProductState } from './product.state';
import * as ProductActions from './product.action';




export const initialState: ProductState = {
  products: [],
  loading: false,
  error: null
};

export const productReducer = createReducer(
  initialState,

  on(ProductActions.loadingProduct, state => ({
    ...state,
    loading: true,
    error: null
  })),

  on(ProductActions.loadingProductSuccess, (state, { products }) => ({
    ...state,
    loading: false,
    products
  })),

  on(ProductActions.loadingProductFail, (state, { error }) => ({
    ...state,
    loading: false,
    error
  }))
);