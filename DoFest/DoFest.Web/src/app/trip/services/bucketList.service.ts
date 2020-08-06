import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BucketListModel } from '../models/bucketList.model';

@Injectable({
  providedIn: 'root'
})
export class BucketListService {

  private endpoint: string = 'http://192.168.100.10:5002/api/v1/bucketlists';

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${localStorage.getItem('userToken')}`
    })
  };

  constructor(private readonly http: HttpClient) { }

  getAll(): Observable<BucketListModel[]> {
    return this.http.get<BucketListModel[]>(this.endpoint, this.httpOptions);
  }

  get(id: string): Observable<BucketListModel> {
    return this.http.get<BucketListModel>(`${this.endpoint}/${id}`, this.httpOptions);
  }

  post(activity: BucketListModel): Observable<any> {
    return this.http.post<any>(this.endpoint, activity, this.httpOptions);
  }

}
