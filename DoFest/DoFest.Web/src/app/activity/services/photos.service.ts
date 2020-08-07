import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PhotoModel } from '../models/photo.model';

@Injectable({
  providedIn: 'root'
})
export class PhotosService {
  private endpoint: string = 'https://127.0.0.1:5001/api/v1/activities';


  private httpOptions = {
    headers: new HttpHeaders({
      //'Content-Type':'application/json',
      'Content-Disposition': 'multipart/form-data',
      'Authorization': `Bearer ${localStorage.getItem('userToken')}`
    })
  };

  constructor(private readonly http: HttpClient) { }

  get(id:string): Observable<PhotoModel[]> {
    return this.http.get<PhotoModel[]>(`${this.endpoint}/${id}/photos`, this.httpOptions);
  }

  post(activityId:string, content:FormData):Observable<HttpResponse<unknown>>{
    return this.http.post<any>(`${this.endpoint}/${activityId}/photos`,content, this.httpOptions);
  }
  delete(activityId:string, photoId:string):Observable<any>{
    return this.http.delete<any>(`${this.endpoint}/${activityId}/photos/${photoId}`, this.httpOptions);
  }
}
