import { Component, OnInit, ViewChild } from '@angular/core';
import {AdminService } from '../../services/admin.service'


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
    public readonly adminService: AdminService
  ) {

  }
  ngOnInit(): void {

  }
}
