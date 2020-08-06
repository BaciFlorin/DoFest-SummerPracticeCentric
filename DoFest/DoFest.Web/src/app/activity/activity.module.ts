import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { SharedModule } from '../shared/shared.module';
import { ActivityListComponent } from './activity-list/activity-list.component';
import { ActivityRoutingModule } from './activity-routing.module';

@NgModule({
  declarations: [ActivityListComponent],
  imports: [CommonModule, ActivityRoutingModule, FormsModule, ReactiveFormsModule, SharedModule],
  exports: [ActivityListComponent],
})
export class ActivityModule { }
