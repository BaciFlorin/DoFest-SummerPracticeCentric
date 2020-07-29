import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators, AbstractControl } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService, CitiesService, UserTypesService} from 'src/app/shared/services';

import { LoginModel } from '../models/login.model';
import { RegisterModel } from '../models/register.model';
import { AuthenticationService } from '../services/authentication.service';

@Component({
  selector: 'app-authentication',
  templateUrl: './authentication.component.html',
  styleUrls: ['./authentication.component.scss'],
  providers: [AuthenticationService],
})
export class AuthenticationComponent implements OnInit{
  public isSetRegistered: boolean = false;
  public formGroup: FormGroup;
  public cities: Array<string> = ["Iasi", "Timisoara", "Cluj"];
  public userTypes: Array<string> = ["Normal user", "Guest"];

  constructor(
    private readonly router: Router,
    private readonly authenticationService: AuthenticationService,
    private readonly formBuilder: FormBuilder,
    private readonly userService: UserService,
    private readonly citiesService: CitiesService,
    private readonly userTypeService: UserTypesService
  ) {
    this.formGroup = this.formBuilder.group({
      email: ['',[Validators.required, Validators.email]],
      password: ['',[Validators.required, Validators.minLength(8)]],
      fullName: ['',[Validators.required]],
      username:['',[Validators.required]],
      city:[this.cities[0],[Validators.required]],
      userType:[this.userTypes[0], [Validators.required]],
      age:[18, [Validators.min(18), Validators.max(99), Validators.required]],
      yearStudy:[1,[Validators.required, Validators.min(1), Validators.max(6)]]
    });
    this.userService.username.next('');
  }
  ngOnInit(): void {
    // aici vom avea nevoie sa luam de la server numele oraselor si tipurile de utilizatori, dar fara admin
    this.citiesService.getCities().subscribe((data)=>{
      console.log(data);
    });

    this.userTypeService.getUserTypes().subscribe((data)=>{
      console.log(data);
    });

  }

  public setRegister(): void {
    this.isSetRegistered = !this.isSetRegistered;
  }

  public authenticate(): void {
    if (this.isSetRegistered) {
      const data: LoginModel = this.formGroup.getRawValue();

      this.authenticationService.register(data).subscribe(() => {
        this.userService.username.next(data.email);
        this.router.navigate(['dashboard']);
      });
    } else {
      const data: RegisterModel = this.formGroup.getRawValue();
      this.formGroup.removeControl('fullName');

      this.authenticationService.login(data).subscribe((logData: any) => {
        localStorage.setItem('userToken', JSON.stringify(logData.token));
        this.userService.username.next(data.email);
        this.router.navigate(['dashboard']);
      });
    }
  }

  public isInvalid(form:AbstractControl)
  {
    return form.invalid && form.touched && form.dirty;
  }
}
