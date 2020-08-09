import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {AdminService } from '../../services/admin.service';
import { ActivityModel } from 'src/app/activity/models';
import { MatTableDataSource } from '@angular/material/table';
import { Subscription } from 'rxjs';
import { HttpResponse } from '@angular/common/http';

@Component({
  selector: 'app-activity-table',
  templateUrl: './activity-table.component.html',
  styleUrls: ['./activity-table.component.scss']
})
export class ActivityTableComponent implements OnInit, OnDestroy {

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  private subs: Subscription[];

  constructor(
    public readonly adminService: AdminService
  ) {
    this.subs = new Array<Subscription>();
  }

  ngOnDestroy(): void{
    this.subs.forEach((sub)=>{
      sub.unsubscribe();
    });
  }

  ngOnInit(): void {
    this.subs.push(this.adminService.getActivities().subscribe( (data: HttpResponse<any>) => {
      if(data.status/100 != 2){
        console.error("Eroare la aducerea datelor Activity de la server!");
        return;
      }
      this.adminService.activityData = data.body;
      this.adminService.activityDataSource = new MatTableDataSource<ActivityModel>(this.adminService.activityData);
      this.adminService.activityDataSource.paginator = this.paginator;
    }));
  }

  public applyFilterTitle(event: Event){
    const filterValue = (event.target as HTMLInputElement).value;
    this.adminService.activityDataSource.filterPredicate = (data, filter): boolean =>{
      console.log(data);
      return data.name.toLowerCase().includes(filter.toLowerCase());
    };
    this.adminService.activityDataSource.filter = filterValue.trim().toLowerCase();
  }

}
