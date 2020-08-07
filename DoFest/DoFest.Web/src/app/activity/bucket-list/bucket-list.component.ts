import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup } from '@angular/forms';
import { BucketListModel } from '../models/bucketList.model';
import { BucketListService} from '../services/bucketList.service';

@Component({
  selector: 'app-bucket-list',
  templateUrl: './bucket-list.component.html',
  styleUrls: ['./bucket-list.component.scss'],
  providers: [BucketListService]
})
export class BucketListComponent implements OnInit {
    public bucketList: BucketListModel[];
    public formGroup: FormGroup;

  constructor(
    private router: Router,
    private service: BucketListService,
    ) { }

  public ngOnInit(): void {
    this.service.getAll().subscribe((data: BucketListModel[]) => {
      this.bucketList = data;
      console.log("am ajuns aici");
    });
  }

  goToBucket(id: string): void {
    this.router.navigate([`/trip/details/${id}`]);
  }
}





