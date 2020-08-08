import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BucketListWithActivitiesModel } from '../../models/bucketListWithActivities.model';
import { BucketListService } from '../../services/bucketList.service';
import { MatSelectChange } from '@angular/material/select';
import { ActivityModule } from 'src/app/activity/activity.module';
import { UpdateBucketListModel } from '../../models/updateBucketList.model';
import { HttpResponse, HttpHandler } from '@angular/common/http';

@Component({
  selector: 'app-bucket',
  templateUrl: './bucket.component.html',
  styleUrls: ['./bucket.component.scss']
})
export class BucketComponent implements OnInit {
 
  constructor(private route:Router, private readonly bucketListService: BucketListService) {
    this.activityForToggle = new Array<string>();
    this.bucketlist = {
      name: "", username: "", activities: []
    };
    this.activityToDelete = new Array<string>();
   }

  public bucketListId:string;
  public bucketlist: BucketListWithActivitiesModel;
  public myBucket: boolean;
  private activityForToggle:Array<string>;
  private activityToDelete: Array<string>;

  ngOnInit(): void {
    let temp = this.route.url.split("/");
    this.bucketListId = temp[temp.length-1];
    console.log(this.bucketListId);

    this.bucketListService.get(this.bucketListId).subscribe((data:BucketListWithActivitiesModel)=>{
      this.bucketlist = data;
      console.log(data);
    });

    this.myBucket = this.bucketListId == JSON.parse(sessionStorage.getItem('identity'))["bucketListId"];
  }

  public addForToggle(id:string, event:MatSelectChange)
  {
    var status = event.value;
    var activity = this.bucketlist.activities.find((activityModel)=>{
      return activityModel.activityId == id;
    });
    if(activity.status != status)
    {
      this.activityForToggle.push(activity.activityId);
    }
    else{
      this.activityForToggle = this.activityForToggle.filter((activityModel)=> {
        return activityModel != id;
      });
    }
  }

  public deleteActivity(id:string)
  {
    if(this.activityToDelete.find((activityId)=> activityId == id) == undefined)
    {
      this.activityToDelete.push(id);
    }
    console.log(this.activityToDelete);
  }

  public undoActivity(id:string)
  {
    this.activityToDelete = this.activityToDelete.filter((activityId)=> activityId != id);
  }

  public forDelete(id:string):boolean
  {
    let result = this.activityToDelete.find((activityId)=> activityId == id) != undefined;
    return result;
  }

  public updateBucketList()
  {
    let newName = (<HTMLInputElement> document.getElementById("bucketlist-name")).value;
    this.activityForToggle = this.activityForToggle.filter((activityId)=> this.activityToDelete.find((deleteId)=> deleteId == activityId) == undefined );
    if(this.activityForToggle.length > 0 || this.activityToDelete.length > 0 || newName != this.bucketlist.name)
    {
      let updateBucket: UpdateBucketListModel = {
        name: newName,
        activitiesForDelete: this.activityToDelete,
        activitiesForToggle: this.activityForToggle
      };

      this.bucketListService.update(updateBucket,this.bucketListId).subscribe((data:HttpResponse<any>)=>{
        if(data.status == 200)
        {
          window.location.reload();
        }
      });
    }
  }

  public goToActivity(id:string)
  {
    this.route.navigate(["activity","details",id]);
  }
}
