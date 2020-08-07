import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AuthenticationComponent } from './authentication/authentication/authentication.component';
import { TripDetailsComponent } from './trip/trip-details/trip-details.component';
import { TripListComponent } from './trip/trip-list/trip-list.component';

import { ActivityDetailsComponent } from './activity/activity-details/activity-details.component';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'authentication',
  },
  {
    path: 'authentication',
    loadChildren: () =>
      import('./authentication/authentication.module').then(
        (m) => m.AuthenticationModule
      ),
  },
  { path: 'list', component: TripListComponent },
  { path: 'create-trip', component: TripDetailsComponent },
  {
    path: 'notifications',
    loadChildren: () =>
      import('./notifications/notifications.module').then(
        (m) => m.NotificationsModule
      ),
  },
  {
    path: 'dashboard',
    loadChildren: () =>
      import('./dashboard/dashboard.module').then((m) => m.DashboardModule),
  },
  {
    path: 'activity',
    loadChildren: () => import('./activity/activity.module').then((m) => m.ActivityModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
