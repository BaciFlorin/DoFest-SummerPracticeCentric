import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { ActivityTypeModel } from '../models/activityType.model';
import { RouteService } from 'src/app/shared/services';

@Injectable({
  providedIn: 'root',
})
export class ActivityTypeService {
  constructor(
    private readonly http: HttpClient,
    private readonly routeService: RouteService
  ) {}

  getAll(): Observable<ActivityTypeModel[]> {
    return this.http.get<ActivityTypeModel[]>(
      this.routeService.getRoute('activityType', 'get all')
    );
  }

  post(activity: ActivityTypeModel): Observable<any> {
    return this.http.post<any>(
      this.routeService.getRoute('activityType', 'add one'),
      activity
    );
  }
}
