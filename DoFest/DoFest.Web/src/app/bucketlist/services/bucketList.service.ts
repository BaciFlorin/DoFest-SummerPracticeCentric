import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { RouteService } from '../../shared/services/route.service';
import { Observable } from 'rxjs';
import { BucketListModel } from '../models/bucketList.model';
import { BucketListWithActivitiesModel } from '../models/bucketListWithActivities.model';
import { UpdateBucketListModel } from '../models/updateBucketList.model';

@Injectable({
  providedIn: 'root',
})
export class BucketListService {
  constructor(
    private readonly http: HttpClient,
    private readonly routeService: RouteService
  ) {}

  getAll(): Observable<BucketListModel[]> {
    return this.http.get<BucketListModel[]>(
      this.routeService.getRoute('bucketlist', 'get all')
    );
  }

  get(id: string): Observable<BucketListWithActivitiesModel> {
    return this.http.get<BucketListWithActivitiesModel>(
      this.routeService.getRoute('bucketlist', 'get one', id)
    );
  }

  update(
    updateModel: UpdateBucketListModel,
    id: string
  ): Observable<HttpResponse<any>> {
    return this.http.put<HttpResponse<any>>(
      this.routeService.getRoute('bucketlist', 'change', id),
      updateModel,
      { observe: 'response' }
    );
  }

  add(bucketId: string, activityId: string): Observable<HttpResponse<any>> {
    return this.http.post<HttpResponse<any>>(
      this.routeService.getRoute('bucketlist', 'add one', bucketId, activityId),
      { observe: 'response' }
    );
  }
}
