import { createFeatureSelector, createSelector } from '@ngrx/store';
import { ProductState } from './product.state';

export const selectProductState = createFeatureSelector<ProductState>('product');

export const selectAllProducts = createSelector(
  selectProductState,
  (state: ProductState) => state.products
);

export const selectProductLoading = createSelector(
  selectProductState,
  (state: ProductState) => state.loading
);

export const selectProductError = createSelector(
  selectProductState,
  (state: ProductState) => state.error
);