import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { ActivityModel, ActivitiesModel } from '../models';
import { TripService } from '../services/trip.service';

@Component({
  selector: 'app-trip-list',
  templateUrl: './trip-list.component.html',
  styleUrls: ['./trip-list.component.scss'],
  providers: [TripService]
})
export class TripListComponent implements OnInit {
  public tripList: ActivityModel[];

  constructor(
    private router: Router,
    private service: TripService,
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
