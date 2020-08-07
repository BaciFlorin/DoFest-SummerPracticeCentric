import { Component, OnInit, ViewChild } from '@angular/core';
import {AdminService } from '../../services/admin.service'
import { FormBuilder, FormControl, FormGroup, Validators, AbstractControl } from '@angular/forms';
import { HttpResponse} from '@angular/common/http';
import { CityModel } from 'src/app/shared/models/city.model';
import { NewActivityTypeModel } from '../../models/activityType/newActivityType';
import { ActivityModel } from 'src/app/activity/models';
import { ActivityTypeModel } from 'src/app/activity/models/activityType.model';


@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css'],
  providers: [
    AdminService
  ]
})
export class AdminComponent implements OnInit {

  public userTypeControl: FormControl = null;

  public cityIdDeleteControl: FormControl = null;
  public cityNameAddControl: FormControl = null;

  public activityTypeDeleteControl: FormControl = null;
  public activityTypeAddControl: FormControl = null;

  public activityDeleteControl: FormControl = null;
  public activityAddGroup: FormGroup = null;


  constructor(
    public readonly adminService: AdminService
  ) {
    this.userTypeControl = new FormControl("");

    this.cityIdDeleteControl = new FormControl("");
    this.cityNameAddControl = new FormControl("");

    this.activityTypeAddControl = new FormControl("");

    this.activityTypeDeleteControl = new FormControl("");

    this.activityDeleteControl = new FormControl("");
    this.activityAddGroup = new FormGroup({
      name: new FormControl(""),
      activityTypeId: new FormControl(""),
      address: new FormControl(""),
      cityId: new FormControl(""),
      description: new FormControl("")
    });
  }

  ngOnInit(): void {

  }

  public updateUserType(): void{
    const data: string = this.userTypeControl.value;
    this.adminService.updateUserType(data).subscribe( (res: HttpResponse<any>) =>{
      console.log(res);
      if(res.status == 200)
      {
        console.log("success");
      }
    });
  }

  public deleteCity(): void{
    const data: string = this.cityIdDeleteControl.value;
    this.adminService.deleteCity(data).subscribe( (res: HttpResponse<any>) => {

    });
  }

  public addCity(): void{
    let cityModel : CityModel = {
      id: "",
      name: ""
    };
    cityModel.name = this.cityNameAddControl.value
    this.adminService.addCity(cityModel).subscribe( (res: HttpResponse<any>) => {

    });
  }

  public deleteActivityType(): void{
    const data: string = this.activityTypeDeleteControl.value;
    this.adminService.deleteActivityType(data).subscribe( (res: HttpResponse<any>) =>{

    });
  }

  public addActivityType(): void{
    let activityTypeModel: ActivityTypeModel = {
      name: this.activityTypeAddControl.value
    };
    this.adminService.addActivityType(activityTypeModel).subscribe( (res: HttpResponse<any>) =>{

    });
  }

  public deleteActivity(): void{
    const data: string = this.activityDeleteControl.value;
    this.adminService.deleteActivity(data).subscribe( (res: HttpResponse<any>) => {

    });
  }

  public addActivity(): void{
    const activityModel: ActivityModel = this.activityAddGroup.getRawValue();
    this.adminService.addActivity(activityModel).subscribe( (res: HttpResponse<any>) =>{
      console.log(res);
    });
  }
}
