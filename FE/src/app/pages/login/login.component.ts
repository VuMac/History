import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DataServices } from 'app/core/api/data.services';
import { userLogin } from 'app/model/user';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from "ngx-toastr";
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  user: userLogin;
  loginForm: FormGroup;
  constructor(
    private toastr: ToastrService,
    private spinnerService: NgxSpinnerService,
    private router: Router,
    private dataServices: DataServices

  ) {
    this.loginForm = new FormGroup({
      username: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required])
    });
  }

  ngOnInit(): void {
  }

  register(){
    this.router.navigate(["register"]);
  }
  login() {
    if (this.loginForm.controls.username.errors || this.loginForm.controls.password.errors) {
      this.toastr.warning(
        "Yêu cầu mật khẩu và username",
        "",
        {
          timeOut: 4000,
          closeButton: true,
          enableHtml: true,
          toastClass: "alert alert-warning alert-with-icon",
          positionClass: "toast-top-right",
        }
      );
      return;
    }

    const username = this.loginForm.controls.username.value;
    const password = this.loginForm.controls.password.value;

    // Kiểm tra chỉ chấp nhận tài khoản admin
    if (username !== "admin") {
      this.toastr.error(
        "Chỉ chấp nhận tài khoản admin",
        "",
        {
          timeOut: 3000,
          closeButton: true,
          enableHtml: true,
          toastClass: "alert alert-danger alert-with-icon",
          positionClass: "toast-top-right",
        }
      );
      return;
    }
    // Hiển thị spinner khi đang gửi yêu cầu
    this.spinnerService.show();
    // Gọi API từ DataServices
    this.dataServices.login(username, password).subscribe(
      (response: any) => {
        // Xử lý khi đăng nhập thành công
        this.spinnerService.hide();
        this.toastr.success(
          "Đăng nhập thành công",
          "",
          {
            timeOut: 3000,
            closeButton: true,
            enableHtml: true,
            toastClass: "alert alert-success alert-with-icon",
            positionClass: "toast-top-right",
          }
        );
        // Lưu token vào localStorage nếu có
        if (response.token) {
          localStorage.setItem("tokenUser", response.token);
        }

        // Điều hướng tới dashboard
        this.router.navigate(["dashboard"]);
      },
      (error) => {
        // Xử lý khi đăng nhập thất bại
        this.spinnerService.hide();
        this.toastr.error(
          "Đăng nhập thất bại. Vui lòng kiểm tra lại thông tin.",
          "",
          {
            timeOut: 3000,
            closeButton: true,
            enableHtml: true,
            toastClass: "alert alert-danger alert-with-icon",
            positionClass: "toast-top-right",
          }
        );
        console.error("Login error:", error);
      }
    );
  }
  // login() {
  //   if (this.loginForm.controls.username.errors || this.loginForm.controls.password.errors) {
  //     this.toastr.warning(
  //       'Yêu cầu mật khẩu và username',
  //       "",
  //       {
  //         timeOut: 4000,
  //         closeButton: true,
  //         enableHtml: true,
  //         toastClass: "alert alert-warning alert-with-icon",
  //         positionClass: "toast-top-right"
  //       }
  //     );
  //     return;
  //   }
  
  //   const username = this.loginForm.controls.username.value;
  //   const password = this.loginForm.controls.password.value;
  
  //   // Kiểm tra chỉ chấp nhận tài khoản admin
  //   if (username !== 'admin') {
  //     this.toastr.error(
  //       'Chỉ chấp nhận tài khoản admin',
  //       "",
  //       {
  //         timeOut: 3000,
  //         closeButton: true,
  //         enableHtml: true,
  //         toastClass: "alert alert-danger alert-with-icon",
  //         positionClass: "toast-top-right"
  //       }
  //     );
  //     return;
  //   }
  
  //   // Hiển thị spinner khi đang gửi yêu cầu
  //   this.spinnerService.show();
  
  //   // Chuẩn bị dữ liệu từ form
  //   const loginData = { username, password };
  
  //   // Gọi API đăng nhập
  //   this.http.post('https://localhost:5000/api/User/login', loginData)
  //     .subscribe(
  //       (response: any) => {
  //         // Xử lý khi đăng nhập thành công
  //         this.spinnerService.hide();
  //         this.toastr.success(
  //           'Đăng nhập thành công',
  //           "",
  //           {
  //             timeOut: 3000,
  //             closeButton: true,
  //             enableHtml: true,
  //             toastClass: "alert alert-success alert-with-icon",
  //             positionClass: "toast-top-right"
  //           }
  //         );
  //         // Lưu token hoặc thông tin người dùng (nếu API trả về token)
  //         if (response.token) {
  //           localStorage.setItem('tokenUser', response.token);
  //         }
  
  //         // Điều hướng tới dashboard
  //         this.router.navigate(["dashboard"]);
  //       },
  //       (error) => {
  //         // Xử lý khi đăng nhập thất bại
  //         this.spinnerService.hide();
  //         this.toastr.error(
  //           'Đăng nhập thất bại. Vui lòng kiểm tra lại thông tin.',
  //           "",
  //           {
  //             timeOut: 3000,
  //             closeButton: true,
  //             enableHtml: true,
  //             toastClass: "alert alert-danger alert-with-icon",
  //             positionClass: "toast-top-right"
  //           }
  //         );
  //         console.error('Login error:', error);
  //       }
  //     );
  // }
  

}
