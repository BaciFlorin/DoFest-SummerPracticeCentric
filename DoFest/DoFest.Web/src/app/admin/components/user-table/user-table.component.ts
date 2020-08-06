import { Component, OnInit, ViewChild } from '@angular/core';

import { UserModel } from '../../models/user/user';
import {AdminService } from '../../services/admin.service';
import {MatTableDataSource} from '@angular/material/table';
import {MatPaginator} from '@angular/material/paginator';

@Component({
  selector: 'app-user-table',
  templateUrl: './user-table.component.html',
  styleUrls: ['./user-table.component.css'],
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
    this.adminService.getUsers().subscribe((data: UserModel[]) =>{
      this.adminService.userData = data;
      this.adminService.userDataSource = new MatTableDataSource<UserModel>(this.adminService.userData);
      this.adminService.userDataSource.paginator = this.paginator;
    });
  }
}
