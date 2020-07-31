import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CitiesService {
  private endpoint:string = "http://192.168.1.102/api/v1/cities";

  constructor(private readonly httpClient: HttpClient) { }

  public getCities(): Observable<unknown>{
    return this.httpClient.get(this.endpoint);
  }
}