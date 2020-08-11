import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginModel } from '../models/login.model';
import { RegisterModel } from '../models/register.model';
import { RouteService } from 'src/app/shared/services';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
  constructor(
    private readonly httpClient: HttpClient,
    private readonly routeService: RouteService
  ) {}

  public login(data: LoginModel): Observable<HttpResponse<unknown>> {
    return this.httpClient.post(
      this.routeService.getRoute('authentication', 'login'),
      data,
      { observe: 'response' }
    );
  }

  public register(data: RegisterModel): Observable<HttpResponse<any>> {
    return this.httpClient.post<HttpResponse<any>>(
      this.routeService.getRoute('authentication', 'register'),
      data,
      { observe: 'response' }
    );
  }
}
