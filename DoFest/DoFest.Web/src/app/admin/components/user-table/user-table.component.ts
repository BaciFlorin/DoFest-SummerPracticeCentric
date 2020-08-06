import { Component, OnInit } from '@angular/core';

import { UserModel } from '../../models/user/user';
import {AdminService } from '../../services/admin.service';
import {MatTableDataSource} from '@angular/material/table';

@Component({
  selector: 'app-user-table',
  templateUrl: './user-table.component.html',
  styleUrls: ['./user-table.component.css'],
  providers: [
    AdminService
  ]
})
export class UserTableComponent implements OnInit {

  constructor(
    public readonly adminService: AdminService
  ) { }

  ngOnInit(): void {
    this.adminService.getUsers().subscribe((data: UserModel[]) =>{
      this.adminService.userData = data;
      this.adminService.userDataSource = new MatTableDataSource<UserModel>(this.adminService.userData);
      this.adminService.userDataSource.paginator = this.adminService.paginator;
    });
  }
}
