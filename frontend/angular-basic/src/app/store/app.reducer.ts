import { ActionReducerMap } from '@ngrx/store';
import { AppState } from './app.state';


import { productReducer } from './product/product.reducer';
//import { userReducer } from './user/user.reducer';


export const appReducers: ActionReducerMap<AppState> = {
    product: productReducer,
    //user: userReducer
};