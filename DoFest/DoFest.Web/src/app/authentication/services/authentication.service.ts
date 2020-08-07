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
  public endpoint: string = "https://127.0.0.1:5001/api/v1/auth";
  constructor(private readonly httpClient: HttpClient) {}

  public login(data: LoginModel): Observable<HttpResponse<unknown>> {
    return this.httpClient.post(`${this.endpoint}/login`,data,{observe:"response"});
  }

  public register(data: RegisterModel): Observable<unknown> {
    return this.httpClient.post(`${this.endpoint}/register`, data, {observe:"response"});
  }
}
