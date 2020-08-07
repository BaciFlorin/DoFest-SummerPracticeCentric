import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

// import { ActivityModel } from '../models';
// import { ActivitiesModel } from '../models/activities.model';

@Injectable({
  providedIn: 'root'
})
export class TripService {

  private endpoint: string = 'http://192.168.0.10:5002/api/v1/activities';

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${JSON.parse(localStorage.getItem('userToken'))}`
    })
  };

  constructor(private readonly http: HttpClient) { }

  // getAll(): Observable<ActivitiesModel> {
  //   return this.http.get<ActivitiesModel>(this.endpoint, this.httpOptions);
  // }

  // get(id: string): Observable<ActivityModel> {
  //   return this.http.get<ActivityModel>(`${this.endpoint}/${id}`, this.httpOptions);
  // }

  // post(trip: ActivityModel): Observable<any> {
  //   return this.http.post<any>(this.endpoint, trip, this.httpOptions);
  // }

  // patch(trip: ActivityModel): Observable<any> {
  //   return this.http.patch<any>(`${this.endpoint}/${trip.id}`, trip, this.httpOptions);
  // }
}
