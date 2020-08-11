import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { BucketListWithActivitiesModel } from '../../models/bucketListWithActivities.model';
import { MatSelectChange } from '@angular/material/select';
import { BucketListService } from '../../services/bucketList.service';
import { Router } from '@angular/router';
import { UpdateBucketListModel } from '../../models/updateBucketList.model';
import { HttpResponse } from '@angular/common/http';
import { Subscription } from 'rxjs';
import {
  FormControl,
  Validators,
  FormGroup,
  FormBuilder,
} from '@angular/forms';

@Component({
  selector: 'app-yourbucket',
  templateUrl: './yourbucket.component.html',
  styleUrls: ['./yourbucket.component.scss'],
})
export class YourbucketComponent implements OnInit, OnDestroy {
  @Input() public bucketlist: BucketListWithActivitiesModel;
  private activityForToggle: Array<string>;
  private activityToDelete: Array<string>;
  @Input() private bucketListId: string;
  private sub: Subscription;
  public inputName: FormControl;

  constructor(
    private route: Router,
    private readonly bucketListService: BucketListService,
    private readonly formBuilder: FormBuilder
  ) {}

  ngOnDestroy(): void {
    if (this.sub != undefined) {
      this.sub.unsubscribe();
    }
  }

  ngOnInit(): void {
    this.activityForToggle = new Array<string>();
    this.activityToDelete = new Array<string>();
    this.inputName = this.formBuilder.control('', [
      Validators.required,
      Validators.minLength(6),
      Validators.maxLength(100),
    ]);
  }

  public addForToggle(id: string, event: MatSelectChange) {
    var status = event.value;
    var activity = this.bucketlist.activities.find((activityModel) => {
      return activityModel.activityId == id;
    });
    if (activity.status != status) {
      this.activityForToggle.push(activity.activityId);
    } else {
      this.activityForToggle = this.activityForToggle.filter(
        (activityModel) => {
          return activityModel != id;
        }
      );
    }
    document.getElementById('response-message').innerHTML = '';
  }

  public deleteActivity(id: string) {
    if (
      this.activityToDelete.find((activityId) => activityId == id) == undefined
    ) {
      this.activityToDelete.push(id);
    }
    document.getElementById('response-message').innerHTML = '';
  }

  public undoActivity(id: string) {
    this.activityToDelete = this.activityToDelete.filter(
      (activityId) => activityId != id
    );
  }

  public forDelete(id: string): boolean {
    let result =
      this.activityToDelete.find((activityId) => activityId == id) != undefined;
    return result;
  }

  public updateBucketList() {
    if (!(this.inputName.invalid && this.inputName.touched)) {
      let newName = this.inputName.value;
      if (newName == '') {
        newName = this.bucketlist.name;
      }
      this.activityForToggle = this.activityForToggle.filter(
        (activityId) =>
          this.activityToDelete.find((deleteId) => deleteId == activityId) ==
          undefined
      );
      if (
        this.activityForToggle.length > 0 ||
        this.activityToDelete.length > 0 ||
        newName != this.bucketlist.name
      ) {
        let updateBucket: UpdateBucketListModel = {
          name: newName,
          activitiesForDelete: this.activityToDelete,
          activitiesForToggle: this.activityForToggle,
        };

        this.activityForToggle = [];
        this.activityToDelete = [];

        this.sub = this.bucketListService
          .update(updateBucket, this.bucketListId)
          .subscribe((data: HttpResponse<any>) => {
            if (data.status == 200) {
              this.bucketlist.activities = this.bucketlist.activities.filter(
                (activity) => {
                  return (
                    updateBucket.activitiesForDelete.find(
                      (id) => id == activity.activityId
                    ) == undefined
                  );
                }
              );

              document.getElementById('response-message').innerHTML =
                'Changes saved!';
            }
          });
      }
    }
  }

  public goToActivity(id: string) {
    this.route.navigate(['activity', 'details', id]);
  }
}
