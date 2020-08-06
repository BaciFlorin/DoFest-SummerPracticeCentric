import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { ActivityModel } from '../models';
import { ActivityService } from '../services/activity.service';
import {ActivityTypeService} from '../services/activityType.service';
import { CityModel } from '../../shared/models/city.model';
import { CitiesService } from 'src/app/shared/services';
import { FormGroup } from '@angular/forms';
import { ActivityTypeModel } from '../models/activityType.model';

@Component({
  selector: 'app-activity-list',
  templateUrl: './activity-list.component.html',
  styleUrls: ['./activity-list.component.scss'],
  providers: [ActivityService]
})
export class TripListComponent implements OnInit {
  public tripList: ActivityModel[];
  public filtredListActivities: ActivityModel[];
  public cities: CityModel[];
  public formGroup: FormGroup;
  public selectedCity: string;
  public selectedType: string;
  public activityTypes: ActivityTypeModel[];

  constructor(
    private router: Router,
    private service: ActivityService,
    private citiesService: CitiesService,
    private actTypeService: ActivityTypeService
    ) { }

  public ngOnInit(): void {
    this.service.getAll().subscribe((data: ActivityModel[]) => {
      this.tripList = data;
      this.filtredListActivities = data;
    });

    this.citiesService.getCities().subscribe((data) => {
      this.cities = data;
      this.formGroup.get('city').setValue(this.cities[0].id);
      this.selectedCity = data[1].id;
    });

    this.actTypeService.getAll().subscribe((data) => {
      this.activityTypes = data;
      this.selectedType = data[1].id;
     });

  }

  goToActivity(id: string): void {
    this.router.navigate([`/trip/details/${id}`]);
  }

  public changeCity(city: string): void {
    this.selectedCity = city; // ce criteriu a selectat user-ul
  }

  public changeActType(type: string): void{
    this.selectedType = type; // ce criteriu a selectat user-ul
  }

  public applyFilters(): void{
    const filteredByCity = this.tripList.filter(s => s.cityId === this.selectedCity);

    const filteredByActivityType = filteredByCity.filter(s => s.activityTypeId === this.selectedType);

    this.filtredListActivities = filteredByActivityType;
  }

}





