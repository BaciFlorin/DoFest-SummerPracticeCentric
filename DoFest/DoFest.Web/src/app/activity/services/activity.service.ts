import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { ActivityModel } from '../models';
import { RouteService } from 'src/app/shared/services';

@Injectable({
  providedIn: 'root',
})
export class ActivityService {
  constructor(
    private readonly http: HttpClient,
    private readonly routeService: RouteService
  ) {}

  getAll(): Observable<HttpResponse<unknown>> {
    return this.http.get<HttpResponse<unknown>>(
      this.routeService.getRoute('activity', 'get all'),
      { observe: 'response' }
    );
  }

  get(id: string): Observable<HttpResponse<unknown>> {
    return this.http.get<HttpResponse<unknown>>(
      this.routeService.getRoute('activity', 'get one', id),
      { observe: 'response' }
    );
  }

  post(activity: ActivityModel): Observable<HttpResponse<unknown>> {
    return this.http.post<HttpResponse<unknown>>(
      this.routeService.getRoute('activity', 'add one'),
      activity,
      { observe: 'response' }
    );
  }
}
