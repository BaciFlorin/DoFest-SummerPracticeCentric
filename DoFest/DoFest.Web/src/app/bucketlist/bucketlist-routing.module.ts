import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BucketListComponent } from './components/bucket-list/bucket-list.component';
import { BucketComponent } from './components/bucket/bucket.component';

const routes: Routes = [
  {
    path: '',
    component: BucketListComponent,
  },
  {
    path: ':bucketListId',
    component: BucketComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class BucketlistRoutingModule {}
