import {Injectable} from '@angular/core';
import {HttpEvent, HttpInterceptor} from '@angular/common/http';
import { HttpHandler, HttpRequest } from '@angular/common/http'
import { Observable } from 'rxjs';

@Injectable()
export class AuthorizationInterceptor implements HttpInterceptor {

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const userToken = localStorage.getItem("userToken");
    if(userToken)
    {
      console.log("Am un token");
      const authReq = req.clone({
        headers: req.headers.set(
        'Authorization', "Bearer " + userToken)
      });
      console.log('Making an authorized request');
      req = authReq;
    }
    return next.handle(req);
  }
}
