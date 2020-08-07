import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ActivityDetailsComponent } from './activity-details/activity-details.component';

const routes: Routes = [
  {
    path: 'details/:id',
    pathMatch: 'full',
    component: ActivityDetailsComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ActivityRoutingModule { }
