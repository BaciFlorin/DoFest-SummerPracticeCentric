import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UserModel } from '../models/user/user';
import { Observable } from 'rxjs';
import { CityModel } from 'src/app/shared/models/city.model';
import { CitiesService } from 'src/app/shared/services';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  private backendEndpoint: string = "https://localhost:5001/api/v1/"
  private endpoints = {
    "activities": this.backendEndpoint + "activities",
    "activityType": this.backendEndpoint + "activities/type",
    "cities": this.backendEndpoint + "cities",
    "users": this.backendEndpoint + "admin"
  };

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${JSON.parse(localStorage.getItem('userToken'))}`
    })
  };

  private httpClient: HttpClient = null;
  private cityService:  CitiesService = null;

  constructor(
    httpClient: HttpClient,
    cityService: CitiesService
    )
    {
    this.httpClient = httpClient;
    this.cityService = cityService;
  }

  public getUsers(): Observable<UserModel[]>{
    return this.httpClient.get<UserModel[]>(this.endpoints["users"] + "/users", this.httpOptions);
  }

  public getCities(): Observable<CityModel[]>{
    return this.cityService.getCities();
  }
}
