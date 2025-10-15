import { createFeatureSelector, createSelector } from '@ngrx/store';
import { ProductState } from './product.reducer';


export const selectProductState = createFeatureSelector<ProductState>('products');
export const selectAllProducts = createSelector(selectProductState, s => s.items);
export const selectProductLoading = createSelector(selectProductState, s => s.loading);
export const selectProductError = createSelector(selectProductState, s => s.error);