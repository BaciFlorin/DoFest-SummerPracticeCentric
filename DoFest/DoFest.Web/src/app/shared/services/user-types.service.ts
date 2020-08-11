import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserTypeModel } from '../models/user-type.model';

@Injectable({
  providedIn: 'root',
})
export class UserTypesService {
  private endpoint: string = 'https://localhost:5001/api/v1/auth/userTypes';

  constructor(private readonly httpClient: HttpClient) {}

  public getUserTypes(): Observable<UserTypeModel[]> {
    return this.httpClient.get<UserTypeModel[]>(this.endpoint);
  }
}
