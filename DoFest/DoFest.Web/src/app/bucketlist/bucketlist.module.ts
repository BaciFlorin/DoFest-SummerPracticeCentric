import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BucketlistRoutingModule } from './bucketlist-routing.module';
import { BucketListComponent } from './components/bucket-list/bucket-list.component';
import { SharedModule } from '../shared/shared.module';
import { BucketComponent } from './components/bucket/bucket.component';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { YourbucketComponent } from './components/yourbucket/yourbucket.component';
import { NormalbucketComponent } from './components/normalbucket/normalbucket.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    BucketListComponent,
    BucketComponent,
    YourbucketComponent,
    NormalbucketComponent,
  ],
  imports: [
    CommonModule,
    BucketlistRoutingModule,
    SharedModule,
    MatButtonModule,
    MatSelectModule,
    MatFormFieldModule,
    MatIconModule,
    ReactiveFormsModule,
  ],
  exports: [BucketListComponent],
})
export class BucketlistModule {}
