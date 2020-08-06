import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { ActivityModel } from '../models';


@Injectable({
  providedIn: 'root'
})
export class ActivityService {

  private endpoint: string = 'https://localhost:5001/api/v1/activities';

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${localStorage.getItem('userToken')}`
    })
  };

  constructor(private readonly http: HttpClient) { }

  getAll(): Observable<ActivityModel[]> {

    return this.http.get<ActivityModel[]>(this.endpoint, this.httpOptions);
  }

  get(id: string): Observable<ActivityModel> {
    return this.http.get<ActivityModel>(`${this.endpoint}/${id}`, this.httpOptions);
  }

  post(activity: ActivityModel): Observable<any> {
    return this.http.post<any>(this.endpoint, activity, this.httpOptions);
  }

  patch(trip: ActivityModel): Observable<any> {
    return this.http.patch<any>(`${this.endpoint}/${trip.id}`, trip, this.httpOptions);
  }
}
