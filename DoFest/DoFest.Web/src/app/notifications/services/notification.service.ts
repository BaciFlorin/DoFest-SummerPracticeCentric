import { Injectable } from '@angular/core';
import { RouteService } from 'src/app/shared/services';
import { Observable } from 'rxjs';
import { NotificationModel } from '../models/notification.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class NotificationService {
  constructor(
    private httpClient: HttpClient,
    private readonly routeService: RouteService
  ) {}

  public getAll(): Observable<NotificationModel[]> {
    return this.httpClient.get<NotificationModel[]>(
      this.routeService.getRoute('notification', 'get all')
    );
  }
}
