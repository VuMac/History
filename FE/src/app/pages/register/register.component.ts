import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { userRegister } from 'app/model/userRegister';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { DataServices } from 'app/core/api/data.services';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  userRegister: userRegister;
  registerForm: FormGroup;
  constructor(
    private data : DataServices,
    private router: Router,
    private toastr: ToastrService) {
    this.registerForm = new FormGroup({
      username: new FormControl('', [Validators.required]),
      fullName: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required])
    })
  }

  ngOnInit(): void {
  }

  loginPage() {
    this.router.navigate(["login"]);
  }

  register(){
    if(this.registerForm.invalid){
      this.toastr.warning("Điền đầy đủ thông tin");
      return;
    }
    this.data.register(this.userRegister).subscribe(res =>{

    })
  }
}
