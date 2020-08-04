import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { ActivityModel, ActivitiesModel } from '../models';
import { ActivityService } from '../services/activity.service';

@Component({
  selector: 'app-trip-list',
  templateUrl: './activity-list.component.html',
  styleUrls: ['./activity-list.component.scss'],
  providers: [ActivityService]
})
export class TripListComponent implements OnInit {
  public tripList: ActivityModel[];

  constructor(
    private router: Router,
    private service: ActivityService,
    ) { }

  public ngOnInit(): void {
    this.service.getAll().subscribe((data: ActivityModel[]) => {
      this.tripList = data;
    });
  }

  goToTrip(id: string): void {
    this.router.navigate([`/trip/details/${id}`]);
  }
}
