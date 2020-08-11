import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { AdminService } from '../../services/admin.service';
import { ActivityTypeModel } from '../../models/activityType/activityType';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { HttpResponse } from '@angular/common/http';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-activity-type-table',
  templateUrl: './activity-type-table.component.html',
  styleUrls: ['./activity-type-table.component.scss'],
})
export class ActivityTypeTableComponent implements OnInit, OnDestroy {
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  private subs: Subscription[];

  constructor(public adminService: AdminService) {
    this.subs = new Array<Subscription>();
  }

  ngOnInit(): void {
    this.subs.push(
      this.adminService
        .getActivityTypes()
        .subscribe((data: HttpResponse<any>) => {
          if (data.status / 100 != 2) {
            console.error(
              'Eroare la aducerea datelor ActivityType de la server.'
            );
            return;
          }
          this.adminService.activityTypeData = data.body;
          this.adminService.activityTypeDataSource = new MatTableDataSource<
            ActivityTypeModel
          >(this.adminService.activityTypeData);
          this.adminService.activityTypeDataSource.paginator = this.paginator;
        })
    );
  }

  ngOnDestroy(): void {
    this.subs.forEach((sub) => {
      sub.unsubscribe();
    });
  }

  public applyFilterName(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.adminService.activityTypeDataSource.filterPredicate = (
      data,
      filter
    ): boolean => {
      return data.name.toLowerCase().includes(filter.toLowerCase());
    };
    this.adminService.activityTypeDataSource.filter = filterValue
      .trim()
      .toLowerCase();
  }
}
