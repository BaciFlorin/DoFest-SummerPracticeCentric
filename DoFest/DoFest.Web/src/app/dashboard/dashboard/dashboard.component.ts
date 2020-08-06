import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CitiesService } from 'src/app/shared/services';
import { HttpResponse } from '@angular/common/http';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
})
export class DashboardComponent {
  constructor(private router: Router) {}

  public goToPage(page: string): void {
    this.router.navigate([page]);
  }

  public isAdmin():boolean{
    var identity = JSON.parse(localStorage.getItem('identity'));
    return identity.isAdmin;
  }
}
