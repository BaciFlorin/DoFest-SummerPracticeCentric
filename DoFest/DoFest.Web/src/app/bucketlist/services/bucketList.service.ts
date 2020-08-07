import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BucketListModel } from '../models/bucketList.model';
import { RouteService } from 'src/app/shared/services';
import { BucketListWithActivitiesModel } from '../models/bucketListWithActivities.model';

@Injectable({
  providedIn: 'root'
})
export class BucketListService {

  constructor(private readonly http: HttpClient, private readonly routeService: RouteService) { }

  getAll(): Observable<BucketListModel[]> {
    return this.http.get<BucketListModel[]>(this.routeService.getRoute("bucketlist", "get all"));
  }

  get(id: string): Observable<BucketListWithActivitiesModel> {
    return this.http.get<BucketListWithActivitiesModel>(this.routeService.getRoute("bucketlist", "get one", id));
  }
}
