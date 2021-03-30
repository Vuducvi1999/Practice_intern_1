import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginServices } from './../../services/login.services';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit, OnDestroy {
  sub: any;
  LoginStatus = '';
  LoginForm = this.fb.group({
    name: ['', Validators.required],
    password: ['', Validators.required],
  });

  constructor(
    private _service: LoginServices,
    private fb: FormBuilder,
    private router: Router
  ) {}

  ngOnInit(): void {}

  Submit(e: any) {
    this.sub = this._service.login(e.value).subscribe(
      (data) => {
        console.log(data);
        this.LoginStatus = 'Login Success!';
        localStorage.setItem('token', data.token);
        this.router.navigate(['/product/page', 1]);
      },
      (err) => {
        this.LoginStatus = 'Login Failed!';
      }
    );
  }

  ngOnDestroy(): void {
    if (this.sub) this.sub.unsubscribe();
  }
}
