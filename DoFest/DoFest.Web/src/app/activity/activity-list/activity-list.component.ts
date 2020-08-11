import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';

import { ActivityModel } from '../models';
import { ActivityService } from '../services/activity.service';
import { ActivityTypeService } from '../services/activityType.service';
import { CityModel } from '../../shared/models/city.model';
import { CitiesService } from 'src/app/shared/services';
import { FormGroup } from '@angular/forms';
import { ActivityTypeModel } from '../models/activityType.model';
import { MatSelectChange } from '@angular/material/select';
import { BucketListService } from 'src/app/bucketlist/services/bucketList.service';
import { Subscription } from 'rxjs';
import { HttpResponse } from '@angular/common/http';

@Component({
  selector: 'app-activity-list',
  templateUrl: './activity-list.component.html',
  styleUrls: ['./activity-list.component.scss'],
  providers: [ActivityService],
})
export class ActivityListComponent implements OnInit, OnDestroy {
  public tripList: ActivityModel[];
  public filtredListActivities: ActivityModel[];
  public cities: CityModel[] = new Array<CityModel>();
  public formGroup: FormGroup;
  public selectedCity: string;
  public selectedType: string;
  public activityTypes: ActivityTypeModel[];
  public bucketListId: string = '';
  public activitiesInBucket: Array<string> = new Array<string>();
  public subscriptions: Array<Subscription> = new Array<Subscription>();

  constructor(
    private router: Router,
    private service: ActivityService,
    private citiesService: CitiesService,
    private actTypeService: ActivityTypeService,
    private bucketService: BucketListService
  ) {}

  ngOnDestroy(): void {
    this.subscriptions.forEach((sub) => {
      sub.unsubscribe();
    });
  }

  public ngOnInit(): void {
    this.bucketListId = JSON.parse(sessionStorage.getItem('identity'))[
      'bucketListId'
    ];
    this.subscriptions.push(
      this.bucketService.get(this.bucketListId).subscribe((data) => {
        this.activitiesInBucket = data.activities.map((act) => act.activityId);
      })
    );

    this.subscriptions.push(
      this.service.getAll().subscribe((data: HttpResponse<any>) => {
        this.tripList = data.body;
        this.filtredListActivities = data.body;
      })
    );

    this.subscriptions.push(
      this.citiesService.getCities().subscribe((data: HttpResponse<any>) => {
        this.cities = data.body;
      })
    );

    this.subscriptions.push(
      this.actTypeService.getAll().subscribe((data) => {
        this.activityTypes = data;
      })
    );
    this.selectedType = 'None';
    this.selectedCity = 'None';
  }

  goToActivity(id: string): void {
    this.router.navigate([`/activity/details/${id}`]);
  }

  public changeCity(cityEvent: MatSelectChange): void {
    this.selectedCity = cityEvent.value; // ce criteriu a selectat user-ul
  }

  public changeType(type: MatSelectChange): void {
    this.selectedType = type.value; // ce criteriu a selectat user-ul
  }

  public applyFilters(): void {
    let filters = new Array<Function>();
    if (this.selectedCity != 'None') {
      filters.push((act: ActivityModel) => act.cityId === this.selectedCity);
    }
    if (this.selectedType != 'None') {
      filters.push(
        (act: ActivityModel) => act.activityTypeId === this.selectedType
      );
    }

    if (filters.length > 0) {
      this.filtredListActivities = this.tripList.filter((s) => {
        let result: boolean = true;
        filters.forEach((filter) => (result = result && filter(s)));
        return result;
      });
    } else {
      this.filtredListActivities = this.tripList;
    }
  }

  getCityName(id: string): string {
    if (this.cities.length == 0) {
      return '';
    }
    return this.cities.find((city) => city.id === id).name;
  }

  addToBucket(id: string) {
    this.activitiesInBucket.push(id);
    this.subscriptions.push(
      this.bucketService.add(this.bucketListId, id).subscribe((data) => {
        this.filtredListActivities.find(
          (activity) => activity.id == id
        ).trending += 1;
      })
    );
  }

  inBucket(id: string): boolean {
    return this.activitiesInBucket.find((actId) => actId === id) != undefined;
  }
}
