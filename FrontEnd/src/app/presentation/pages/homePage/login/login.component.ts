import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from 'src/app/domain/services/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  returnUrl = 'dashboard';
  formLogin: FormGroup;
  error = '';

  constructor(
    private formBuilder: FormBuilder,
    private authenticationService: AuthenticationService,
    private router: Router,
    private route: ActivatedRoute,
  )
  {
    this.formLogin = formBuilder.group({ username: [null, Validators.required], password: [null, Validators.required] });
  }

  ngOnInit(): void {
  }

  onSubmit() {
    if (this.formLogin.invalid){
      return;
    }

  this.authenticationService.login(this.formLogin.value)
  .subscribe({
        next: () => {
        this.router.navigate(['dashboard']);
    },
    error: error => {
      this.error = error.error;}
      });
    }

  onCancel() {
    this.router.navigate(['']);
  }
}
