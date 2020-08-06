import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { CommentModel } from '../models/comment.model';
import {CreateCommentModel} from '../models/createcomment.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CommentsService {

  private endpoint: string = 'https://127.0.0.1:5001/api/v1/activities';

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${localStorage.getItem('userToken')}`
    })
  };

  constructor(private readonly http: HttpClient) { }

  get(id:string): Observable<CommentModel[]> {
    return this.http.get<CommentModel[]>(`${this.endpoint}/${id}/comments`, this.httpOptions);
  }

  delete(activityId:string, commentId:string):Observable<any>{
    return this.http.delete<any>(`${this.endpoint}/${activityId}/comments/${commentId}`, this.httpOptions);
  }

  post(activityId:string, comment:CreateCommentModel):Observable<any>{
    return this.http.post<any>(`${this.endpoint}/${activityId}/comments`,comment, this.httpOptions);
  }
}
