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

  constructor(
  ) {

  }
  ngOnInit(): void {

  }

}
