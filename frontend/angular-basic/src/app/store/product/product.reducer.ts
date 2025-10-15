import { createReducer, on } from '@ngrx/store';
import * as ProductActions from './product.action';
import { Product } from '../../model/product';


export interface ProductState {
items: Product[];
loading: boolean;
error: any | null;
}


export const initialState: ProductState = {
items: [],
loading: false,
error: null,
};


export const productReducer = createReducer(
initialState,
on(ProductActions.loadProducts, state => ({ ...state, loading: true, error: null })),
on(ProductActions.loadProductsSuccess, (state, { products }) => ({ ...state, loading: false, items: products })),
on(ProductActions.loadProductsFailure, (state, { error }) => ({ ...state, loading: false, error })),


on(ProductActions.createProduct, state => ({ ...state, loading: true })),
on(ProductActions.createProductSuccess, (state, { product }) => ({ ...state, loading: false, items: [...state.items, product] })),
on(ProductActions.createProductFailure, (state, { error }) => ({ ...state, loading: false, error })),


on(ProductActions.updateProduct, state => ({ ...state, loading: true })),
on(ProductActions.updateProductSuccess, (state, { product }) => ({ ...state, loading: false, items: state.items.map(p => p.id === product.id ? product : p) })),
on(ProductActions.updateProductFailure, (state, { error }) => ({ ...state, loading: false, error })),


on(ProductActions.deleteProduct, state => ({ ...state, loading: true })),
on(ProductActions.deleteProductSuccess, (state, { id }) => ({ ...state, loading: false, items: state.items.filter(p => p.id !== id) })),
on(ProductActions.deleteProductFailure, (state, { error }) => ({ ...state, loading: false, error }))
);