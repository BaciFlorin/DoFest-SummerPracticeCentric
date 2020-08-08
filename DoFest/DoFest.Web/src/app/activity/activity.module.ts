import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { ActivityDetailsComponent } from './activity-details/activity-details.component';
import { ActivityListComponent } from './activity-list/activity-list.component';
import { ActivityRoutingModule } from './activity-routing.module';
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';
import {MatDividerModule} from '@angular/material/divider';
import {MatIconModule} from '@angular/material/icon';
import { BarRatingModule } from "ngx-bar-rating";
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [ActivityDetailsComponent, ActivityListComponent],
  imports: [
    CommonModule,
    ActivityRoutingModule,
    MatButtonModule,
    MatCardModule,
    MatDividerModule,
    MatIconModule,
    ReactiveFormsModule,
    BarRatingModule,
    SharedModule,
  	FormsModule
  ],
  exports: [ActivityDetailsComponent, ActivityListComponent]
})
export class ActivityModule { }
