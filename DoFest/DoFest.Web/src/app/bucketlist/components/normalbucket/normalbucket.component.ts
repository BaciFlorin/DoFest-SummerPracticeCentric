import { Component, OnInit, Input } from '@angular/core';
import { BucketListWithActivitiesModel } from '../../models/bucketListWithActivities.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-normalbucket',
  templateUrl: './normalbucket.component.html',
  styleUrls: ['./normalbucket.component.scss'],
})
export class NormalbucketComponent implements OnInit {
  constructor(private route: Router) {}

  @Input() public bucketlist: BucketListWithActivitiesModel;

  ngOnInit(): void {}

  public goToActivity(id: string) {
    this.route.navigate(['activity', 'details', id]);
  }
}
