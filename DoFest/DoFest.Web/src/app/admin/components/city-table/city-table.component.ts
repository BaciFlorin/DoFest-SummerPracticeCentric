import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';

import { AdminService } from '../../services/admin.service';
import { CityModel } from 'src/app/shared/models/city.model';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { Subscription } from 'rxjs';
import { HttpResponse } from '@angular/common/http';

@Component({
  selector: 'app-city-table',
  templateUrl: './city-table.component.html',
  styleUrls: ['./city-table.component.scss'],
})
export class CityTableComponent implements OnInit, OnDestroy {
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
    this.subs.push(
      this.adminService.getCities().subscribe((data: HttpResponse<any>) => {
        if (data.status / 100 != 2) {
          console.error('Eroare la aducerea datelor City de la server!');
          return;
        }
        this.adminService.cityData = data.body;
        this.adminService.cityDataSource = new MatTableDataSource<CityModel>(
          this.adminService.cityData
        );
        this.adminService.cityDataSource.paginator = this.paginator;
      })
    );
  }
  public applyFilterName(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.adminService.cityDataSource.filterPredicate = (
      data,
      filter
    ): boolean => {
      return data.name.toLowerCase().includes(filter.toLowerCase());
    };
    this.adminService.cityDataSource.filter = filterValue.trim().toLowerCase();
  }
}
