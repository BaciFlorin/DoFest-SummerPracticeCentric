import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { ActivityModel } from '../models';


@Injectable({
  providedIn: 'root'
})
export class ActivityService {

  private endpoint: string = 'http://192.168.0.103:5002/api/v1/activities';

  constructor(private readonly http: HttpClient) { }

  getAll(): Observable<ActivityModel[]> {

    return this.http.get<ActivityModel[]>(this.endpoint);
  }

  get(id: string): Observable<ActivityModel> {
    return this.http.get<ActivityModel>(`${this.endpoint}/${id}`);
  }

  post(activity: ActivityModel): Observable<any> {
    return this.http.post<any>(this.endpoint, activity);
  }

  patch(trip: ActivityModel): Observable<any> {
    return this.http.patch<any>(`${this.endpoint}/${trip.id}`, trip);
  }
}
