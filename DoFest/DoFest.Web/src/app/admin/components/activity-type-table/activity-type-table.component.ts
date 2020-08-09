import { Component, OnInit, ViewChild } from '@angular/core';
import { AdminService } from '../../services/admin.service';
import { ActivityTypeModel } from '../../models/activityType/activityType';
import {MatTableDataSource} from '@angular/material/table';
import {MatPaginator} from '@angular/material/paginator';

@Component({
  selector: 'app-activity-type-table',
  templateUrl: './activity-type-table.component.html',
  styleUrls: ['./activity-type-table.component.scss']
})
export class ActivityTypeTableComponent implements OnInit {

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

  constructor(
    public adminService: AdminService
  ) { }

  ngOnInit(): void {
    this.adminService.getActivityTypes().subscribe( (data: ActivityTypeModel[]) => {
      this.adminService.activityTypeData = data;
      this.adminService.activityTypeDataSource = new MatTableDataSource<ActivityTypeModel>(this.adminService.activityTypeData);
      this.adminService.activityTypeDataSource.paginator = this.paginator;
    });
  }

  public applyFilterName(event: Event){
    const filterValue = (event.target as HTMLInputElement).value;
    this.adminService.activityTypeDataSource.filterPredicate = (data, filter): boolean =>{
      return data.name.toLowerCase().includes(filter.toLowerCase());
    };
    this.adminService.activityTypeDataSource.filter = filterValue.trim().toLowerCase();
  }

}
