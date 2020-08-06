import { Component, OnInit } from '@angular/core';

import {AdminService } from '../../services/admin.service';
import { CityModel } from 'src/app/shared/models/city.model';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-city-table',
  templateUrl: './city-table.component.html',
  styleUrls: ['./city-table.component.css']
})
export class CityTableComponent implements OnInit {

  constructor(
    public readonly adminService: AdminService
  ) { }

  ngOnInit(): void {
    this.adminService.getCities().subscribe( (data: CityModel[]) => {
      this.adminService.cityData = data;
      this.adminService.cityDataSource = new MatTableDataSource<CityModel>(this.adminService.cityData);
      this.adminService.cityDataSource.paginator = this.adminService.paginator;
    });
  }

}
