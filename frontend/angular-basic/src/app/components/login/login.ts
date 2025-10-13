import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import * as AuthActions from '../../store/auth/auth.action';
import { Store } from '@ngrx/store';
import { selectLoading, selectError, selectIsAuthenticated } from '../../store/auth/auth.selector';
import { LoginRequest } from '../../model/Login';
import { AsyncPipe, NgIf } from '@angular/common';



@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, AsyncPipe, NgIf],
  templateUrl: './login.html',
  styleUrls: ['./login.css']
})
export class Login {

  constructor(private store: Store, private router: Router) {}
  
  loading$!: Observable<boolean>;
  error$!: Observable<string>;
  isAuthenticated$!: Observable<boolean>;
  email: string ='';
  password: string = '';

   ngOnInit() {
    this.loading$ = this.store.select(selectLoading);
    this.error$ = this.store.select(selectError);
    this.isAuthenticated$ = this.store.select(selectIsAuthenticated);
  }

    onLogin(email: string, password: string) {
    const data: LoginRequest = { email, password };
    this.store.dispatch(AuthActions.login({ data }));
    
  }
}
