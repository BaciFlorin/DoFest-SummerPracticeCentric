import { Injectable } from '@angular/core';
import {CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot} from '@angular/router';


@Injectable()
export class AuthGuard implements CanActivate{
    constructor(private router: Router) {}

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | import("@angular/router").UrlTree | import("rxjs").Observable<boolean | import("@angular/router").UrlTree> | Promise<boolean | import("@angular/router").UrlTree> {
        const userToken = localStorage.getItem('userToken');
        if(userToken == undefined)
        {
            this.router.navigate(['authentication']);
            return false;
        }
        return true;
    }

}