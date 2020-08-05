import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { ActivityModel } from '../models';
import { ActivitiesModel } from '../models/activities.model';
import { ActivityTypeModel } from '../models/activityType.model';


@Injectable({
  providedIn: 'root'
})
export class ActivityTypeService {

  private endpoint: string = 'http://192.168.100.10:5002/api/v1/activities/types';

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${JSON.parse(localStorage.getItem('userToken'))}`
    })
  };

  constructor(private readonly http: HttpClient) { }

  getAll(): Observable<ActivityTypeModel[]> {
    console.log(this.httpOptions);
    return this.http.get<ActivityTypeModel[]>(this.endpoint, this.httpOptions);
  }

  post(activity: ActivityTypeModel): Observable<any> {
    return this.http.post<any>(this.endpoint, activity, this.httpOptions);
  }
}
