import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';


import { TripDetailsComponent } from './trip/trip-details/trip-details.component';
import { TripListComponent } from './trip/trip-list/trip-list.component';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'authentication',
  },
  {
    path: 'admin',
    loadChildren: () =>
    import('./admin/admin.module').then(
      (m) => m.AdminModule
    ),
  },
  {
    path: 'authentication',
    loadChildren: () =>
      import('./authentication/authentication.module').then(
        (m) => m.AuthenticationModule
      ),
  },
  {
    path: 'list',
    component: TripListComponent
  },
  {
    path: 'create-trip',
    component: TripDetailsComponent
  },
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
    path: 'trip',
    loadChildren: () => import('./trip/trip.module').then((m) => m.TripModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
