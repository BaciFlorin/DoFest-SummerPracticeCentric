import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ActivityRoutingModule } from './activity-routing.module';
import { ActivityDetailsComponent } from './activity-details/activity-details.component';
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';
import {MatDividerModule} from '@angular/material/divider';
import {MatIconModule} from '@angular/material/icon';
import { ReactiveFormsModule } from '@angular/forms';
import { BarRatingModule } from "ngx-bar-rating";

@NgModule({
  declarations: [ActivityDetailsComponent],
  imports: [
    CommonModule,
    ActivityRoutingModule,
    MatButtonModule,
    MatCardModule,
    MatDividerModule,
    MatIconModule,
    ReactiveFormsModule,
    BarRatingModule
  ],
  exports: [ActivityDetailsComponent]
})
export class ActivityModule { }
