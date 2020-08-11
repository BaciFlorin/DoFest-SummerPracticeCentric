import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';

import { UserModel } from '../../models/user/user';
import { AdminService } from '../../services/admin.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { HttpResponse } from '@angular/common/http';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-user-table',
  templateUrl: './user-table.component.html',
  styleUrls: ['./user-table.component.scss'],
  providers: [AdminService],
})
export class UserTableComponent implements OnInit, OnDestroy {
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  private subs: Subscription[];

  constructor(public readonly adminService: AdminService) {
    this.subs = new Array<Subscription>();
  }

  ngOnDestroy(): void {
    this.subs.forEach((sub) => {
      sub.unsubscribe();
    });
  }

  ngOnInit(): void {
    // Request the usertypes from the backend
    this.subs.push(
      this.adminService.getUserTypes().subscribe((data: HttpResponse<any>) => {
        if (data.status / 100 != 2) {
          console.error('Eroare la aducerea datelor UserType de la server.');
          return;
        }
        this.adminService.userTypeData = data.body;
        // When the usertype data is received request the user data
        this.subs.push(
          this.adminService.getUsers().subscribe((data: HttpResponse<any>) => {
            if (data.status / 100 != 2) {
              console.error('Eroare la aducerea datelor User de la server.');
              return;
            }
            this.adminService.userData = data.body;
            this.adminService.userData.map((elementUser) => {
              const obj = this.adminService.userTypeData.find(
                (o) => o.id == elementUser.userTypeId
              );
              elementUser.userType = obj.name;
            });
            this.adminService.userDataSource = new MatTableDataSource<
              UserModel
            >(this.adminService.userData);
            this.adminService.userDataSource.paginator = this.paginator;
          })
        );
      })
    );
  }

  public applyFilterEmail(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.adminService.userDataSource.filterPredicate = (
      data,
      filter
    ): boolean => {
      return data.email.toLowerCase().includes(filter.toLowerCase());
    };
    this.adminService.userDataSource.filter = filterValue.trim().toLowerCase();
  }

  public applyFilterUsername(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.adminService.userDataSource.filterPredicate = (
      data,
      filter
    ): boolean => {
      return data.username.toLowerCase().includes(filter.toLowerCase());
    };
    this.adminService.userDataSource.filter = filterValue.trim().toLowerCase();
  }
}
