import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PhotoModel } from '../models/photo.model';
import { RouteService } from 'src/app/shared/services/route.service';

@Injectable({
  providedIn: 'root',
})
export class PhotosService {
  constructor(
    private readonly http: HttpClient,
    private readonly routeService: RouteService
  ) {}

  get(id: string): Observable<PhotoModel[]> {
    return this.http.get<PhotoModel[]>(
      this.routeService.getRoute('photo', 'get all', id)
    );
  }

  post(
    activityId: string,
    content: FormData
  ): Observable<HttpResponse<unknown>> {
    return this.http.post<any>(
      this.routeService.getRoute('photo', 'add one', activityId),
      content
    );
  }
  delete(activityId: string, photoId: string): Observable<any> {
    return this.http.delete<any>(
      this.routeService.getRoute('photo', 'delete', activityId, photoId)
    );
  }
}
