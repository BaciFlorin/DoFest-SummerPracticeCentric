import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators, AbstractControl } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService, CitiesService} from 'src/app/shared/services';

import { LoginModel } from '../models/login.model';
import { RegisterModel } from '../models/register.model';
import { AuthenticationService } from '../services/authentication.service';
import { UserTypeModel } from '../../shared/models/user-type.model';
import { CityModel } from '../../shared/models/city.model';
import { HttpResponse, HttpErrorResponse } from '@angular/common/http';


@Component({
  selector: 'app-authentication',
  templateUrl: './authentication.component.html',
  styleUrls: ['./authentication.component.scss'],
  providers: [AuthenticationService],
})
export class AuthenticationComponent implements OnInit{
  public isSetRegistered: boolean = false;
  public formGroup: FormGroup;
  public cities: CityModel[];

  constructor(
    private readonly router: Router,
    private readonly authenticationService: AuthenticationService,
    private readonly formBuilder: FormBuilder,
    private readonly userService: UserService,
    private readonly citiesService: CitiesService
  ) {
    this.formGroup = this.formBuilder.group({
      email: ['',[Validators.required, Validators.email]],
      password: ['',[Validators.required, Validators.minLength(8)]],
      name: ['',[Validators.required]],
      username:['',[Validators.required]],
      city:['', [Validators.required]],
      age:[18, [Validators.min(18), Validators.max(99), Validators.required]],
      year:[1,[Validators.required, Validators.min(1), Validators.max(6)]],
      bucketlistname:['',[Validators.required, Validators.minLength(6)]]
    });
    this.userService.username.next('');
  }

  ngOnInit(): void {
    this.citiesService.getCities().subscribe((data)=>{
      this.cities = data;
      this.formGroup.get('city').setValue(this.cities[0].id);
    });
    localStorage.clear();
  }

  public setRegister(): void {
    this.isSetRegistered = !this.isSetRegistered;
    cleanErrorList();
    if(!this.isSetRegistered)
    {
      this.formGroup.markAsUntouched();
      this.formGroup.setValue({email:'', password:'',name:'', username:'', city:this.cities[0].id,age:18, yearStudy:1});
    }
  }

  public authenticate(): void {
    if (this.isSetRegistered) {
      const data: RegisterModel = this.formGroup.getRawValue();
      this.authenticationService.register(data).subscribe((registerData: HttpResponse<any>) => {
        if(registerData.status == 201)
        {
          this.setRegister();
          document.getElementById('successful-register').innerHTML = "Successful register user, please log in!";
        }
      }, this.handleError);
    }
    else {
        const data: LoginModel = this.formGroup.getRawValue();
        this.authenticationService.login(data).subscribe((data: HttpResponse<any>) => {
        if(data.status == 200)
        {
          localStorage.setItem('userToken', data.body["token"]);
          localStorage.setItem('identity', JSON.stringify(data.body));
          this.userService.username.next(data.body.username);
          this.router.navigate(['dashboard']);
        }
        }, this.handleError);
      }
    }

  public isInvalid(form:AbstractControl):boolean
  {
    return form.invalid && form.touched && form.dirty && this.isSetRegistered;
  }

  private handleError(responseError:HttpErrorResponse):void
  {
    cleanErrorList();
    if(responseError.status == 400)
    {
      if("errors" in responseError.error)
      {
        let errorList: Array<string> = responseError.error.errors;
        for(var error in errorList)
        {
          var newError = document.createElement('div');
          newError.className = "error-item";
          newError.innerHTML = errorList[error][0];
          document.getElementById("error-list").appendChild(newError);
        }
      }
      else
      {
        var newError = document.createElement('div');
        newError.className = "error-item";
        newError.innerHTML = responseError.error.message;
        document.getElementById("error-list").appendChild(newError);
      }
    }
  }
}

function cleanErrorList():void
{
  let errorList = document.getElementById("error-list").childNodes;
  errorList.forEach((child)=>{
    document.getElementById("error-list").removeChild(child);
  });
}
