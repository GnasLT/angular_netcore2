import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AuthService, LoginRequest } from '../../service/authen/authen'
import { HttpClientModule } from '@angular/common/http';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class Login {
  email: string = '';
  password: string = '';
  errorMessage: string = '';

  constructor(private authService: AuthService, private router: Router) {}

  onSubmit(): void {
    const request: LoginRequest = {
      email: this.email,
      password: this.password
  };
    this.authService.login(request).subscribe({
      next: (res) => console.log('Login success:', res),
      error: (err) => console.error('Login failed:', err)
    });
  }
}
