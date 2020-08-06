import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { ActivityModel } from '../models/activity.model';
import { Observable, Subscription } from 'rxjs';
import { CommentModel } from '../models/comment.model';

@Injectable({
  providedIn: 'root'
})
export class ActivityService {
  private endpoint: string = 'https://127.0.0.1:5001/api/v1/activities';



  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${localStorage.getItem('userToken')}`
    })
  };

  constructor(private readonly http: HttpClient) { }

  get(id: string): Observable<ActivityModel> {
    return this.http.get<ActivityModel>(`${this.endpoint}/${id}`, this.httpOptions);
  }


}
