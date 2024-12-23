// src/app/login/login.component.ts
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../auth.service';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  isSubmitting: boolean = false;
  errorMessage: string = '';
  returnUrl: string = '/';

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router,
    private route: ActivatedRoute,
    private http: HttpClient
  ) {
    this.loginForm = this.fb.group({
      username: ['', [Validators.required]],
      password: ['', [Validators.required]]
    });
  }

  ngOnInit(): void {
    // Lấy returnUrl từ query parameters nếu có
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/dashboard';
  }

  onSubmit() {
    if (this.loginForm.valid) {
      this.isSubmitting = true;
      const { username, password } = this.loginForm.value;
     // Kiểm tra nếu username không phải 'admin'
     
     if (username.trim().toLowerCase() !== 'admin') {
      this.errorMessage = 'Tên đăng nhập không hợp lệ. Chỉ admin mới được phép đăng nhập.';
      this.isSubmitting = false;
      return; // Ngăn không cho tiếp tục gửi yêu cầu đăng nhập
    }

      // Gọi API đăng nhập (thay 'https://your-api.com/login' bằng URL thực tế)
      this.http.post<any>('https://localhost:5000/api/User/login', { username, password })
        .subscribe({
          next: (response) => {
            // Giả sử API trả về token
            this.authService.login(response.token);
            this.isSubmitting = false;
            // Chuyển hướng đến returnUrl
            this.router.navigateByUrl(this.returnUrl);
          },
          error: (error) => {
            console.error('Login failed:', error);
            this.errorMessage = 'Tên đăng nhập hoặc mật khẩu không đúng';
            this.isSubmitting = false;
          }
        });
    }
  }
}
