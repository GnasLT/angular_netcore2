import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LoginRequest } from '../../model/Login';


@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'http://localhost:5088/api/UserAction'; 

  constructor(private http: HttpClient) {}

  // Đăng nhập => server set cookie
  login(data: LoginRequest): Observable<any> {
    return this.http.post(`${this.apiUrl}/login`, data, {
      withCredentials: true   
    });
  }

//   // Lấy thông tin user đang đăng nhập (nếu cookie còn)
//   getCurrentUser(): Observable<any> {
//     return this.http.get(`${this.apiUrl}/me`, {
//       withCredentials: true   
//     });
//   }


  logout(): Observable<any> {
    return this.http.post(`${this.apiUrl}/logout`, {}, {
      withCredentials: true
    });
  }
}
