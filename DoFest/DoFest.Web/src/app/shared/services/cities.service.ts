import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RouteService } from './route.service';

@Injectable({
  providedIn: 'root',
})
export class CitiesService {
  constructor(
    private readonly httpClient: HttpClient,
    private readonly routeService: RouteService
  ) {}

  public getCities(): Observable<HttpResponse<unknown>> {
    return this.httpClient.get<HttpResponse<unknown>>(
      this.routeService.getRoute('city', 'get all'),
      { observe: 'response' }
    );
  }
}
