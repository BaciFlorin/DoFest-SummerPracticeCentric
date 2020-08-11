import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { BucketListWithActivitiesModel } from '../../models/bucketListWithActivities.model';
import { BucketListService } from '../../services/bucketList.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-bucket',
  templateUrl: './bucket.component.html',
  styleUrls: ['./bucket.component.scss'],
})
export class BucketComponent implements OnInit, OnDestroy {
  constructor(
    private route: Router,
    private readonly bucketListService: BucketListService
  ) {
    this.bucketlist = {
      name: '',
      username: '',
      activities: [],
    };
  }

  ngOnDestroy(): void {
    if (this.sub != undefined) {
      this.sub.unsubscribe();
    }
  }

  public bucketListId: string;
  public bucketlist: BucketListWithActivitiesModel;
  public myBucket: boolean;
  private sub: Subscription;

  ngOnInit(): void {
    let temp = this.route.url.split('/');
    this.bucketListId = temp[temp.length - 1];

    this.sub = this.bucketListService
      .get(this.bucketListId)
      .subscribe((data: BucketListWithActivitiesModel) => {
        this.bucketlist = data;
      });

    this.myBucket =
      this.bucketListId ==
      JSON.parse(sessionStorage.getItem('identity'))['bucketListId'];
  }
}
