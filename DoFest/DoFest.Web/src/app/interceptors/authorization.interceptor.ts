import { Injectable } from '@angular/core';
import {
  HttpEvent,
  HttpInterceptor,
  HttpResponse,
  HttpErrorResponse,
} from '@angular/common/http';
import { HttpHandler, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';

@Injectable()
export class AuthorizationInterceptor implements HttpInterceptor {
  constructor(private router: Router) {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    const userToken = sessionStorage.getItem('userToken');
    if (userToken) {
      const authReq = req.clone({
        headers: req.headers.set('Authorization', 'Bearer ' + userToken),
      });
      req = authReq;
    }
    return next.handle(req);
  }
}
