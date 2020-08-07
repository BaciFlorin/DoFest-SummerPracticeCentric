import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '../app/guards/auth.guard';
import { AdminGuard } from '../app/guards/admin.guard';
import { ActivityListComponent } from './activity/activity-list/activity-list.component';
import { BucketListComponent } from './activity/bucket-list/bucket-list.component';

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
    canActivate: [AuthGuard, AdminGuard]
  },
  {
    path: 'authentication',
    loadChildren: () =>
      import('./authentication/authentication.module').then(
        (m) => m.AuthenticationModule
      )
  },
  { path: 'list', component: ActivityListComponent, canActivate:[AuthGuard] },
  {
    path: 'notifications',
    loadChildren: () =>
      import('./notifications/notifications.module').then(
        (m) => m.NotificationsModule
      ),
    canActivate:[AuthGuard]
  },
  {
    path: 'dashboard',
    loadChildren: () =>
      import('./dashboard/dashboard.module').then((m) => m.DashboardModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'activity',
    loadChildren: () => import('./activity/activity.module').then((m) => m.ActivityModule),
  },
  { path: 'bucketLists', component : BucketListComponent, canActivate:[AuthGuard]},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
