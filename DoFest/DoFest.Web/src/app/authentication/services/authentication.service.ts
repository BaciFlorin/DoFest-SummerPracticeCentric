import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { LoginModel } from '../models/login.model';
import { RegisterModel } from '../models/register.model';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
  public endpoint: string = "http://192.168.0.102:5002/api/v1/auth";
  constructor(private readonly httpClient: HttpClient) {}

  public login(data: LoginModel): Observable<HttpResponse<unknown>> {
    return this.httpClient.post(`${this.endpoint}/login`,data,{observe:"response"});
  }

  public register(data: RegisterModel): Observable<unknown> {
    return this.httpClient.post(`${this.endpoint}/register`, data, {observe:"response"});
  }
}
