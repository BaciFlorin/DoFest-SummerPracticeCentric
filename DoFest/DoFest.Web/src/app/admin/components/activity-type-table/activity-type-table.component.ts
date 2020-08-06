import { Component, OnInit } from '@angular/core';
import { AdminService } from '../../services/admin.service';
import { ActivityTypeModel } from '../../models/activityType/activityType';
import {MatTableDataSource} from '@angular/material/table';

@Component({
  selector: 'app-activity-type-table',
  templateUrl: './activity-type-table.component.html',
  styleUrls: ['./activity-type-table.component.css']
})
export class ActivityTypeTableComponent implements OnInit {

  constructor(
    public adminService: AdminService
  ) { }

  ngOnInit(): void {
    this.adminService.getActivityTypes().subscribe( (data: ActivityTypeModel[]) => {
      this.adminService.activityTypeData = data;
      this.adminService.activityTypeDataSource = new MatTableDataSource<ActivityTypeModel>(this.adminService.activityTypeData);
      this.adminService.activityTypeDataSource.paginator = this.adminService.paginator;
    });
  }

}
