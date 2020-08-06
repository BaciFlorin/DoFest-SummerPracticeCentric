import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { SharedModule } from '../shared/shared.module';
import { TripDetailsComponent } from './trip-details/trip-details.component';
import { TripListComponent } from './activity-list/activity-list.component';
import { TripRoutingModule } from './trip-routing.module';
import { BucketListComponent } from './bucket-list/bucket-list.component';

@NgModule({
  declarations: [TripDetailsComponent, TripListComponent, BucketListComponent],
  imports: [CommonModule, TripRoutingModule, FormsModule, ReactiveFormsModule, SharedModule],
  exports: [TripDetailsComponent, TripListComponent, BucketListComponent],
})
export class TripModule { }
