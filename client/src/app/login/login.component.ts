import { Component } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  model: any = {}
  loginForm: FormGroup = new FormGroup({});

  constructor(public accountService: AccountService, private fb: FormBuilder, private router: Router, private toastr: ToastrService) {}

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm() {
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  login(){
    const values = {...this.loginForm.value}
    this.accountService.login(values).subscribe({
      next: _ => {this.router.navigateByUrl('/dashboard')}
    })
  }
}
