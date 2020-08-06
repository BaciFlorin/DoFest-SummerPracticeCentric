import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { ActivityModel, ActivitiesModel } from '../models';
import { ActivityService } from '../services/activity.service';
import {ActivityTypeService} from '../services/activityType.service';
import { CityModel } from '../../shared/models/city.model';
import { CitiesService } from 'src/app/shared/services';
import { FormGroup } from '@angular/forms';
import { ActivityTypeModel } from '../models/activityType.model';

@Component({
  selector: 'app-trip-list',
  templateUrl: './activity-list.component.html',
  styleUrls: ['./activity-list.component.scss'],
  providers: [ActivityService]
})
export class ActivityListComponent implements OnInit {
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
    private readonly citiesService: CitiesService,
    private actTypeService: ActivityTypeService
    ) { }

  public ngOnInit(): void {

    this.service.getAll().subscribe((data: ActivityModel[]) => {
      this.tripList = data;
      this.filtredListActivities = data;
    });

    this.citiesService.getCities().subscribe((data) => {
      this.cities = data;
      //this.formGroup.get('city').setValue(this.cities[0].id);
    });

    this.actTypeService.getAll().subscribe((data) => {
      this.activityTypes = data;
    });

  }

  goToActivity(id: string): void {
    this.router.navigate([`/activity/details/${id}`]);
  }

  public changeCity(city: string): void {
    this.selectedCity = city;

    var actArray = this.tripList.filter(s => s.cityId === this.selectedCity);

    this.filtredListActivities = actArray;

  }

  public changeActType(type: string): void{
    this.selectedType = type;

    var actArray = this.tripList.filter(s => s.activityTypeId === this.selectedType);

    this.filtredListActivities = actArray;
  }

}





