import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
})
export class DashboardComponent {
  constructor(private router: Router, private readonly helper:JwtHelperService) {}

  public goToPage(page: string): void {
    this.router.navigate([page]);
  }

  public isAdmin():boolean{
    var decodedToken = this.helper.decodeToken(localStorage.getItem("userToken"));
    if("isAdmin" in decodedToken)
    {
      return true;
    }
    return false;
  }
}
