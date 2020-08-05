import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {CityModel} from './../models/city.model'

@Injectable({
  providedIn: 'root'
})
export class CitiesService {
  private endpoint:string = "https://localhost:5001/api/v1/cities";

  constructor(private readonly httpClient: HttpClient) { }

  public getCities(): Observable<CityModel[]>{
    return this.httpClient.get<CityModel[]>(this.endpoint);
  }
}
