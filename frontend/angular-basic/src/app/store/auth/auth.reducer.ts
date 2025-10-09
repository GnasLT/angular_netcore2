import {createReducer, on} from '@ngrx/store'
import { AuthState } from './auth.state';
import * as UserActions from './auth.action';



export const initialState: AuthState = {
    loading: false,
    error: '',
    isAuthenticated: false
};


export const authReducer = createReducer(
  initialState,

    on(UserActions.login, state =>({
        ...state,
        loading: true,
        error: '',
        isAuthenticated: false
    })),

        on(UserActions.loginSuccess, state =>({
        ...state,
        loading: false,
        isAuthenticated: true,
        error:''
    })),

    on(UserActions.loginFailure, (state, {error}) =>({
    ...state,
    loading: false,
    isAuthenticated: false,
    error
  }))

)