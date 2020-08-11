import { Injectable } from '@angular/core';
import { HttpResponse, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RatingModel } from '../models/rating.model';
import { RouteService } from '../../shared/services/route.service';

@Injectable({
  providedIn: 'root',
})
export class RatingsService {
  constructor(
    private readonly http: HttpClient,
    private readonly routeService: RouteService
  ) {}

  get(id: string): Observable<RatingModel[]> {
    return this.http.get<RatingModel[]>(
      this.routeService.getRoute('rating', 'get all', id)
    );
  }

  post(activityId: string, rating: any): Observable<HttpResponse<unknown>> {
    return this.http.post<any>(
      this.routeService.getRoute('rating', 'add one', activityId),
      rating
    );
  }
}
