import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { RouteService } from 'src/app/shared/services';
import { Observable } from 'rxjs';
import { NewPasswordModel } from '../models/newpassword.model';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(
    private readonly httpClient: HttpClient,
    private readonly routeService: RouteService
  ) {}

  public changePassword(
    data: NewPasswordModel
  ): Observable<HttpResponse<unknown>> {
    return this.httpClient.put(
      this.routeService.getRoute('authentication', 'change password'),
      data,
      { observe: 'response' }
    );
  }
}
