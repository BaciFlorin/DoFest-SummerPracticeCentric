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

  private endpoint: string = 'http://192.168.0.103:5002/api/v1/activities/types';

  constructor(private readonly http: HttpClient) { }

  getAll(): Observable<ActivityTypeModel[]> {
    return this.http.get<ActivityTypeModel[]>(this.endpoint);
  }

  post(activity: ActivityTypeModel): Observable<any> {
    return this.http.post<any>(this.endpoint, activity);
  }
}
