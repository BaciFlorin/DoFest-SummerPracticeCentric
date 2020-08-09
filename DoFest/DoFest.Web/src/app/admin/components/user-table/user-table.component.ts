import { Component, OnInit, ViewChild } from '@angular/core';

import { UserModel } from '../../models/user/user';
import {AdminService } from '../../services/admin.service';
import {MatTableDataSource} from '@angular/material/table';
import {MatPaginator} from '@angular/material/paginator';
import { UserTypeModel } from 'src/app/shared/models/city.model';

@Component({
  selector: 'app-user-table',
  templateUrl: './user-table.component.html',
  styleUrls: ['./user-table.component.scss'],
  providers: [
    AdminService
  ]
})
export class UserTableComponent implements OnInit {

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

  constructor(
    public readonly adminService: AdminService
  ) { }

  ngOnInit(): void {
    // Request the usertypes from the backend
    this.adminService.getUserTypes().subscribe((data: UserTypeModel[]) =>{
      this.adminService.userTypeData = data;
      // When the usertype data is received request the user data
      this.adminService.getUsers().subscribe((data: UserModel[]) =>{
        this.adminService.userData = data;
        this.adminService.userData.map(elementUser => {
          const obj = this.adminService.userTypeData.find( o => o.id == elementUser.userTypeId)
          elementUser.userType = obj.name;
        });
        this.adminService.userDataSource = new MatTableDataSource<UserModel>(this.adminService.userData);
        this.adminService.userDataSource.paginator = this.paginator;
      });
    });
  }

  public applyFilterEmail(event: Event){
    const filterValue = (event.target as HTMLInputElement).value;
    this.adminService.userDataSource.filterPredicate = (data, filter): boolean =>{
      return data.email.toLowerCase().includes(filter.toLowerCase());
    };
    this.adminService.userDataSource.filter = filterValue.trim().toLowerCase();
  }

  public applyFilterUsername(event: Event){
    const filterValue = (event.target as HTMLInputElement).value;
    this.adminService.userDataSource.filterPredicate = (data, filter): boolean =>{
      return data.username.toLowerCase().includes(filter.toLowerCase());
    };
    this.adminService.userDataSource.filter = filterValue.trim().toLowerCase();
  }
}
