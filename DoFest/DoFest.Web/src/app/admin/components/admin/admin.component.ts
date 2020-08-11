import { Component, OnInit, OnDestroy } from '@angular/core';
import { AdminService } from '../../services/admin.service';
import { FormControl, FormGroup } from '@angular/forms';
import { HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { CityModel } from 'src/app/shared/models/city.model';
import { ActivityModel } from 'src/app/activity/models';
import { ActivityTypeModel } from 'src/app/activity/models/activityType.model';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss'],
  providers: [AdminService],
})
export class AdminComponent implements OnInit, OnDestroy {
  public userTypeControl: FormControl = null;

  public cityIdDeleteControl: FormControl = null;
  public cityNameAddControl: FormControl = null;

  public activityTypeDeleteControl: FormControl = null;
  public activityTypeAddControl: FormControl = null;

  public activityDeleteControl: FormControl = null;
  public activityAddGroup: FormGroup = null;

  private subs: Subscription[];

  constructor(public readonly adminService: AdminService) {
    this.userTypeControl = new FormControl('');

    this.cityIdDeleteControl = new FormControl('');
    this.cityNameAddControl = new FormControl('');

    this.activityTypeAddControl = new FormControl('');

    this.activityTypeDeleteControl = new FormControl('');

    this.activityDeleteControl = new FormControl('');
    this.activityAddGroup = new FormGroup({
      name: new FormControl(''),
      activityTypeId: new FormControl(''),
      address: new FormControl(''),
      cityId: new FormControl(''),
      description: new FormControl(''),
    });

    this.subs = new Array<Subscription>();
  }

  ngOnDestroy(): void {
    this.subs.forEach((sub) => {
      sub.unsubscribe;
    });
  }

  ngOnInit(): void {}

  public updateUserType(): void {
    const data: string = this.userTypeControl.value;
    this.subs.push(
      this.adminService.updateUserType(data).subscribe(
        (res: HttpResponse<any>) => {
          if (res.status == 200) {
            alert('UserType changed!');
            window.location.reload();
          }
        },
        () => {
          alert('Bad request! Try Again!');
        }
      )
    );
  }

  public deleteCity(): void {
    const data: string = this.cityIdDeleteControl.value;
    this.subs.push(
      this.adminService.deleteCity(data).subscribe(
        (res: HttpResponse<any>) => {
          if (res.status == 200) {
            alert('City deleted!');
            window.location.reload();
          }
        },
        () => {
          alert('Bad request! Try Again!');
        }
      )
    );
  }

  public addCity(): void {
    let cityModel: CityModel = {
      id: '',
      name: '',
    };
    cityModel.name = this.cityNameAddControl.value;
    this.subs.push(
      this.adminService.addCity(cityModel).subscribe(
        (res: HttpResponse<any>) => {
          if (res.status == 200) {
            alert('City added!');
            window.location.reload();
          }
        },
        () => {
          alert('Bad request! Try Again!');
        }
      )
    );
  }

  public deleteActivityType(): void {
    const data: string = this.activityTypeDeleteControl.value;
    this.subs.push(
      this.adminService.deleteActivityType(data).subscribe(
        (res: HttpResponse<any>) => {
          if (res.status == 200) {
            alert('ActivityType deleted!');
            window.location.reload();
          }
        },
        () => {
          alert('Bad request! Try Again!');
        }
      )
    );
  }

  public addActivityType(): void {
    let activityTypeModel: ActivityTypeModel = {
      name: this.activityTypeAddControl.value,
    };
    this.subs.push(
      this.adminService.addActivityType(activityTypeModel).subscribe(
        (res: HttpResponse<any>) => {
          if (res.status == 201) {
            alert('ActivityType added!');
            window.location.reload();
          }
        },
        () => {
          alert('Bad request! Try Again!');
        }
      )
    );
  }

  public deleteActivity(): void {
    const data: string = this.activityDeleteControl.value;
    this.subs.push(
      this.adminService.deleteActivity(data).subscribe(
        (res: HttpResponse<any>) => {
          if (res.status == 200) {
            alert('Activity deleted!');
            window.location.reload();
          }
        },
        () => {
          alert('Bad request! Try Again!');
        }
      )
    );
  }

  public addActivity(): void {
    const activityModel: ActivityModel = this.activityAddGroup.getRawValue();
    this.subs.push(
      this.adminService.addActivity(activityModel).subscribe(
        (res: HttpResponse<any>) => {
          if (res.status == 201) {
            alert('Activity added!');
            window.location.reload();
          }
        },
        () => {
          alert('Bad request! Try Again!');
        }
      )
    );
  }
}
