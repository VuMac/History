// src/app/auth.service.ts
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor() { }

  // Kiểm tra xem người dùng đã đăng nhập chưa
  isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }

  // Đăng nhập và lưu token
  login(token: string): void {
    localStorage.setItem('token', token);
  }

  // Đăng xuất và xóa token
  logout(): void {
    localStorage.removeItem('token');
  }
}
