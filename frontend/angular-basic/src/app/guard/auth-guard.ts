import { Injectable } from '@angular/core';
import { CanActivate, CanLoad, ActivatedRouteSnapshot, RouterStateSnapshot, Route, UrlSegment, Router } from '@angular/router';
import { Observable, map, take } from 'rxjs';
import { Store } from '@ngrx/store';
import { selectIsAuthenticated, selectRole } from '../store/auth/auth.selector';

@Injectable({
  providedIn: 'root',
})
export class authGuard implements CanLoad, CanActivate {
  constructor(private store: Store, private router: Router) {}

  private checkAccess(): Observable<boolean> {
    return this.store.select(selectIsAuthenticated).pipe(
      take(1),
      map(isAuth => {
        if (!isAuth) {
          this.router.navigate(['/login']);
          return false;
        }
        return true;
      })
    );
  }

  // Chạy trước khi load module
  canLoad(route: Route, segments: UrlSegment[]): Observable<boolean> {
    return this.checkAccess();
  }

  // Chạy khi route được kích hoạt
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
    return this.store.select(selectRole).pipe(
      take(1),
      map(role => {
        if (role === 'admin') return true;
        this.router.navigate(['/unauthorized']);
        return false;
      })
    );
  }
}
