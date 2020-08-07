import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { ActivityModel } from '../models';
import { RouteService } from 'src/app/shared/services';


@Injectable({
  providedIn: 'root'
})
export class ActivityService {

  constructor(private readonly http: HttpClient, private readonly routeService: RouteService) { }

  getAll(): Observable<ActivityModel[]> {

    return this.http.get<ActivityModel[]>(this.routeService.getRoute("activity", "get all"));
  }

  get(id: string): Observable<ActivityModel> {
    return this.http.get<ActivityModel>(this.routeService.getRoute("activity","get one", id));
  }

  post(activity: ActivityModel): Observable<any> {
    return this.http.post<any>(this.routeService.getRoute("activity","add one"), activity);
  }
}
