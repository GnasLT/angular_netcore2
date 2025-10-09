import { createFeatureSelector, createSelector } from '@ngrx/store';
import { AuthState } from './auth.state';

export const selectAuthState = createFeatureSelector<AuthState>('auth');

export const selectLoading = createSelector(
  selectAuthState,
  (state: AuthState) => state.loading
);

export const selectIsAuthenticated = createSelector(
  selectAuthState,
  (state: AuthState) => state.isAuthenticated
);


export const selectError = createSelector(
  selectAuthState,
  (state: AuthState) => state.error
);