import { createAction, props } from "@ngrx/store";
import { LoginRequest } from "../../model/Login";


export const login = createAction('[Auth] Login', props<{ data : LoginRequest }>());
export const loginSuccess = createAction('[Auth] Login Success');
export const loginFailure = createAction('[Auth] Login Failure', props<{ error: string }>());



export const logout = createAction('[Auth] Logout');
export const logoutSuccess = createAction('[Auth] Logout Success');