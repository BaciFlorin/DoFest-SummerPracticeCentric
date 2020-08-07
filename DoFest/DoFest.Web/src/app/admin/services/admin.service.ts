import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UserModel } from '../models/user/user';
import { Observable } from 'rxjs';
import { CityModel } from 'src/app/shared/models/city.model';
import { CitiesService } from 'src/app/shared/services';
import {MatTableDataSource} from '@angular/material/table';
import { ActivityModel } from 'src/app/activity/models';
import { ActivityService } from 'src/app/activity/services/activity.service';
import {ActivityTypeModel} from "../models/activityType/activityType";

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  // ********** User table data **********
  userDisplayedColumns: string[] = ['Id', 'Username', 'Email', 'UserType'];
  userData: UserModel[] = null;
  userDataSource: MatTableDataSource<UserModel> = null;

  // ********** City table data **********
  cityDisplayedColumns: string[] = ['Id', 'Name'];
  cityData: CityModel[] = null;
  cityDataSource: MatTableDataSource<CityModel> = null;

  // ********** Activity table data **********
  activityDisplayedColumns: string[] = ['Id', 'Title', "Description"];
  activityData: ActivityModel[] = null;
  activityDataSource: MatTableDataSource<ActivityModel> = null;

  // ********** ActivityType table data **********
  activityTypeDisplayedColumns: string[] = ['Id', 'Name'];
  activityTypeData: ActivityTypeModel[] = null;
  activityTypeDataSource: MatTableDataSource<ActivityTypeModel> = null;

  private backendEndpoint: string = "http://192.168.0.103:5002/api/v1/"
  private endpoints = {
    "activities": this.backendEndpoint + "activities",
    "activityType": this.backendEndpoint + "activities/types",
    "cities": this.backendEndpoint + "cities",
    "users": this.backendEndpoint + "admin"
  };


  private httpClient: HttpClient = null;
  private cityService: CitiesService = null;
  private activityService: ActivityService = null;

  constructor(
    httpClient: HttpClient,
    cityService: CitiesService,
    activityService: ActivityService
    )
    {
    this.httpClient = httpClient;
    this.cityService = cityService;
    this.activityService = activityService;
  }

  public getUsers(): Observable<UserModel[]>{
    return this.httpClient.get<UserModel[]>(this.endpoints["users"] + "/users");
  }

  public getCities(): Observable<CityModel[]>{
    return this.cityService.getCities();
  }

  public getActivities(): Observable<ActivityModel[]>{
    return this.activityService.getAll();
  }

  public getActivityTypes(): Observable<ActivityTypeModel[]>{
    return this.httpClient.get<ActivityTypeModel[]>(this.endpoints["activityType"]);
  }
}
