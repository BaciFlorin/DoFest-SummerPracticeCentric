import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { ActivityModel, ActivitiesModel } from '../models';
import { ActivityService } from '../services/activity.service';
import { CityModel } from '../../shared/models/city.model';
import { CitiesService } from 'src/app/shared/services';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-trip-list',
  templateUrl: './activity-list.component.html',
  styleUrls: ['./activity-list.component.scss'],
  providers: [ActivityService]
})
export class TripListComponent implements OnInit {
  public tripList: ActivityModel[];
  public cities: CityModel[];
  public formGroup: FormGroup;
  public CitiesToShow: string;
  public selectedCity: string;

  constructor(
    private router: Router,
    private service: ActivityService,
    private readonly citiesService: CitiesService
    ) { }

  public ngOnInit(): void {
    this.service.getAll().subscribe((data: ActivityModel[]) => {
      this.tripList = data;
    });

    this.citiesService.getCities().subscribe((data) => {
      this.cities = data;
      this.formGroup.get('city').setValue(this.cities[0].id);
    });
  }

  goToTrip(id: string): void {
    this.router.navigate([`/trip/details/${id}`]);
  }

  public changeCity(): void {
    this.CitiesToShow = this.selectedCity;
    console.log("dsagadga");
  }
}





