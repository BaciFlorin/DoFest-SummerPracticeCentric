import { Injectable } from '@angular/core';
import { HttpHeaders, HttpResponse, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RatingModel } from '../models/rating.model';

@Injectable({
  providedIn: 'root'
})
export class RatingsService {
  private endpoint: string = 'https://127.0.0.1:5001/api/v1/activities';


  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':'application/json',
      'Authorization': `Bearer ${localStorage.getItem('userToken')}`
    })
  };

  constructor(private readonly http: HttpClient) { }

  get(id:string): Observable<RatingModel[]> {
    return this.http.get<RatingModel[]>(`${this.endpoint}/${id}/ratings`, this.httpOptions);
  }

  post(activityId:string,rating:string ):Observable<HttpResponse<unknown>>{
    return this.http.post<any>(`${this.endpoint}/${activityId}/ratings`,rating, this.httpOptions);
  }
}
