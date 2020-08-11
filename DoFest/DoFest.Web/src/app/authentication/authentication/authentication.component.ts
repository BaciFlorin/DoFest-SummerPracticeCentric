import { Component, OnInit, OnDestroy } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  Validators,
  AbstractControl,
} from '@angular/forms';
import { Router } from '@angular/router';
import { UserService, CitiesService } from 'src/app/shared/services';
import { JwtHelperService } from '@auth0/angular-jwt';

import { LoginModel } from '../models/login.model';
import { RegisterModel } from '../models/register.model';
import { AuthenticationService } from '../services/authentication.service';
import { CityModel } from '../../shared/models/city.model';
import { HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-authentication',
  templateUrl: './authentication.component.html',
  styleUrls: ['./authentication.component.scss'],
  providers: [AuthenticationService],
})
export class AuthenticationComponent implements OnInit, OnDestroy {
  public isSetRegistered: boolean = false;
  public formGroup: FormGroup;
  public cities: CityModel[];
  private subs: Subscription[];

  constructor(
    private readonly router: Router,
    private readonly authenticationService: AuthenticationService,
    private readonly formBuilder: FormBuilder,
    private readonly userService: UserService,
    private readonly citiesService: CitiesService,
    private readonly tokenHelper: JwtHelperService
  ) {
    this.formGroup = this.formBuilder.group({
      email: [
        '',
        [Validators.required, Validators.email, Validators.maxLength(200)],
      ],
      password: [
        '',
        [
          Validators.required,
          Validators.minLength(8),
          Validators.maxLength(60),
        ],
      ],
      name: ['', [Validators.required, Validators.maxLength(150)]],
      username: [
        '',
        [
          Validators.required,
          Validators.minLength(6),
          Validators.maxLength(50),
        ],
      ],
      city: ['', [Validators.required]],
      age: [18, [Validators.min(18), Validators.max(99), Validators.required]],
      year: [1, [Validators.required, Validators.min(1), Validators.max(6)]],
      bucketlistname: [
        '',
        [
          Validators.required,
          Validators.minLength(6),
          Validators.maxLength(100),
        ],
      ],
    });
    this.userService.username = '';
    this.subs = new Array<Subscription>();
  }
  ngOnDestroy(): void {
    this.subs.forEach((sub) => {
      sub.unsubscribe();
    });
  }

  ngOnInit(): void {
    this.subs.push(
      this.citiesService.getCities().subscribe((data: HttpResponse<any>) => {
        this.cities = data.body;
        this.formGroup.get('city').setValue(this.cities[0].id);
      })
    );
    sessionStorage.clear();
  }

  public setRegister(): void {
    this.isSetRegistered = !this.isSetRegistered;
    cleanErrorList();
    if (!this.isSetRegistered) {
      this.formGroup.markAsUntouched();
      this.formGroup.setValue({
        email: '',
        password: '',
        name: '',
        username: '',
        city: this.cities[0].id,
        age: 18,
        year: 1,
        bucketlistname: ''
      });
    }
  }

  public authenticate(): void {
    if (this.isSetRegistered) {
      const data: RegisterModel = this.formGroup.getRawValue();
      this.subs.push(
        this.authenticationService
          .register(data)
          .subscribe((data: HttpResponse<any>) => {
            if (data.status == 201) {
              this.setRegister();
              document.getElementById('successful-register').innerHTML =
                'Successful register user, please log in!';
            }
          }, this.handleError)
      );
    } else {
      const data: LoginModel = this.formGroup.getRawValue();
      this.subs.push(
        this.authenticationService
          .login(data)
          .subscribe((data: HttpResponse<any>) => {
            if (data.status == 200) {
              sessionStorage.setItem('userToken', data.body['token']);
              sessionStorage.setItem('identity', JSON.stringify(data.body));
              this.userService.username = data.body.username;
              this.router.navigate(['dashboard']);
            }
          }, this.handleError)
      );
    }
  }

  public isInvalid(form: AbstractControl): boolean {
    return form.invalid && form.touched && form.dirty;
  }

  private handleError(responseError: HttpErrorResponse): void {
    cleanErrorList();
    if (responseError.status == 400) {
      if ('errors' in responseError.error) {
        let errorList: Array<string> = responseError.error.errors;
        for (var error in errorList) {
          var newError = document.createElement('div');
          newError.className = 'error-item';
          newError.innerHTML = errorList[error][0];
          document.getElementById('error-list').appendChild(newError);
        }
      } else {
        var newError = document.createElement('div');
        newError.className = 'error-item';
        newError.innerHTML = responseError.error.message;
        document.getElementById('error-list').appendChild(newError);
      }
    }
  }
}

function cleanErrorList(): void {
  let errorList = document.getElementById('error-list').childNodes;
  errorList.forEach((child) => {
    document.getElementById('error-list').removeChild(child);
  });
}
