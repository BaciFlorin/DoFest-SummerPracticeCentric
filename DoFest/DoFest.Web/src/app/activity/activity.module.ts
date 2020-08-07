import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { SharedModule } from '../shared/shared.module';
import { ActivityListComponent } from './activity-list/activity-list.component';
import { ActivityRoutingModule } from './activity-routing.module';
import { BucketListComponent } from './bucket-list/bucket-list.component';

@NgModule({
  declarations: [ActivityListComponent, BucketListComponent],
  imports: [CommonModule, ActivityRoutingModule, FormsModule, ReactiveFormsModule, SharedModule],
  exports: [ActivityListComponent, BucketListComponent],
})
export class ActivityModule { }
