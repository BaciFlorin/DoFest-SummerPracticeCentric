import { Component, OnInit } from '@angular/core';

import {AdminService } from '../../services/admin.service';
import { ActivityModel } from 'src/app/trip/models';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-activity-table',
  templateUrl: './activity-table.component.html',
  styleUrls: ['./activity-table.component.css']
})
export class ActivityTableComponent implements OnInit {

  constructor(
    public readonly adminService: AdminService
  ) { }

  ngOnInit(): void {
    this.adminService.getActivities().subscribe( (data: ActivityModel[]) => {
      this.adminService.activityData = data;
      this.adminService.activityDataSource = new MatTableDataSource<ActivityModel>(this.adminService.activityData);
      this.adminService.activityDataSource.paginator = this.adminService.paginator;
    });

  }

}
