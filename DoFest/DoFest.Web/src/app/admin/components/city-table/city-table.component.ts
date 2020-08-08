import { Component, OnInit, ViewChild } from '@angular/core';

import {AdminService } from '../../services/admin.service';
import { CityModel } from 'src/app/shared/models/city.model';
import { MatTableDataSource } from '@angular/material/table';
import {MatPaginator} from '@angular/material/paginator';

@Component({
  selector: 'app-city-table',
  templateUrl: './city-table.component.html',
  styleUrls: ['./city-table.component.scss']
})
export class CityTableComponent implements OnInit {

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

  constructor(
    public readonly adminService: AdminService
  ) { }

  ngOnInit(): void {
    this.adminService.getCities().subscribe( (data: CityModel[]) => {
      this.adminService.cityData = data;
      this.adminService.cityDataSource = new MatTableDataSource<CityModel>(this.adminService.cityData);
      this.adminService.cityDataSource.paginator = this.paginator;
    });
  }
  public applyFilterName(event: Event){
    const filterValue = (event.target as HTMLInputElement).value;
    this.adminService.cityDataSource.filterPredicate = (data, filter): boolean =>{
      return data.name.toLowerCase().includes(filter.toLowerCase());
    };
    this.adminService.cityDataSource.filter = filterValue.trim().toLowerCase();
  }

}
