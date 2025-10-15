import { Injectable, inject } from "@angular/core";
import { AuthService } from "../../service/authen/authen";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { catchError, map, mergeMap, of, tap } from "rxjs";
import * as AuthActions from './auth.action';
import { Router } from '@angular/router';


@Injectable()
export class AuthEffects {
  private actions$ = inject(Actions);
  private authService = inject(AuthService);
  private router = inject(Router);

  login$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(AuthActions.login),
      mergeMap(({ data }) => {
        return this.authService.login(data).pipe(
          map(() => AuthActions.loginSuccess()),
          catchError((err: any) => of(AuthActions.loginFailure({ error: err?.message ?? String(err) })))
        );
      })
    );
  });

  loginSuccess$ = createEffect(() =>
  this.actions$.pipe(
    ofType(AuthActions.loginSuccess),
    map(() => AuthActions.getMe())
  ));

  getme$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(AuthActions.getMe),
      mergeMap(({  }) => {
        console.log('Calling authService.getme authService =', this.authService);
        return this.authService.getme().pipe(
          map(res => AuthActions.getMeSuccess({myrole : res})),
          catchError((err: any) => of(AuthActions.getMeFailure({ error: err?.message ?? String(err) })))
        );
      })
    );
  });

  getMeSuccess$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(AuthActions.getMeSuccess),
        tap(({ myrole }) => {
          if (myrole === 'admin') this.router.navigate(['/admin']);
          else if (myrole === 'seller')this.router.navigate(['/dashboard']);
          else this.router.navigate(['/home']);
        })
      ),
    { dispatch: false }
  );
  constructor() {}

}
