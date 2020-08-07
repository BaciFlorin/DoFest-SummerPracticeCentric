import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ActivityListComponent } from './activity-list/activity-list.component';

const routes: Routes = [
  {
    path: 'details/:id',
  {
    path: 'list',
    pathMatch: 'full',
    component: ActivityListComponent,
  }
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ActivityRoutingModule { }