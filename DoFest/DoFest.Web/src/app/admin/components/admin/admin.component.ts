import { Component, OnInit, ViewChild } from '@angular/core';
import {AdminService } from '../../services/admin.service'
import {MatPaginator} from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';
import { UserModel } from '../../models/user/user';


@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css'],
  providers: [
    AdminService
  ]
})
export class AdminComponent implements OnInit {

  displayedColumns: string[] = ['Id', 'Username', 'Email', 'UserType', "StudentId", "BucketListId"];
  userData: UserModel[] = null;
  dataSource: MatTableDataSource<UserModel> = null;
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

  constructor(
    private readonly adminService: AdminService
  ) {

  }

  ngOnInit(): void {
    this.adminService.getUsers().subscribe((data: UserModel[]) =>{
      this.userData = data;
    });
    this.dataSource = new MatTableDataSource<UserModel>(this.userData);
    this.dataSource.paginator = this.paginator;
  }

}
