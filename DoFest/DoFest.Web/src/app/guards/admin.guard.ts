import { Injectable } from '@angular/core';
import {
  CanActivate,
  Router,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
} from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable()
export class AdminGuard implements CanActivate {
  constructor(private router: Router, private helper: JwtHelperService) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ):
    | boolean
    | import('@angular/router').UrlTree
    | import('rxjs').Observable<boolean | import('@angular/router').UrlTree>
    | Promise<boolean | import('@angular/router').UrlTree> {
    const userToken = sessionStorage.getItem('userToken');
    if (userToken != undefined) {
      let decodedToken = this.helper.decodeToken(userToken);
      if ('isAdmin' in decodedToken) {
        return true;
      }
    }
    this.router.navigate(['authentication']);
    return false;
  }
}
