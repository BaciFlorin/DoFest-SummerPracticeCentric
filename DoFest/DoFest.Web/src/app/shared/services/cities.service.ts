import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {CityModel} from './../models/city.model'
import { RouteService } from './route.service';

@Injectable({
  providedIn: 'root'
})
export class CitiesService {
  constructor(private readonly httpClient: HttpClient, private readonly routeService:RouteService) { }

  public getCities(): Observable<CityModel[]>{
    return this.httpClient.get<CityModel[]>(this.routeService.getRoute("city","get all"));
  }
}
