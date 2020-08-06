import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';

import { ActivityService } from '../services/activity.service';
import { Subscription } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { ActivityModel } from '../models/activity.model';
import { CitiesService } from '../../shared/services/cities.service';
import { CommentsService } from '../services/comments.service';
import { PhotosService } from '../services/photos.service';
import { CityModel } from 'src/app/shared/models/city.model';
import { CommentModel } from '../models/comment.model';
import { PhotoModel } from '../models/photo.model';

@Component({
  selector: 'app-activity-details',
  templateUrl: './activity-details.component.html',
  styleUrls: ['./activity-details.component.scss'],
  providers: [FormBuilder],
})
export class ActivityDetailsComponent implements OnInit, OnDestroy {
  fileToUpload: any;
  imageUrl: any;
  activity: ActivityModel;
  city: CityModel;
  formGroup: FormGroup;
  isShowComments: boolean;
  photos: Blob[] = [];
  comments: CommentModel[];
  photo:PhotoModel;

  private routeSub: Subscription = new Subscription();

  get comment(): string {
    return this.formGroup.get('content').value;
  }

  constructor(
    private formBuilder: FormBuilder,
    private activityService: ActivityService,
    private commentsService: CommentsService,
    private photosService: PhotosService,
    private citiesService: CitiesService,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.formGroup = this.formBuilder.group({
      activityId: new FormControl(),
      content: new FormControl(),
    });

    this.isShowComments = false;

    this.routeSub = this.activatedRoute.params.subscribe((params) => {
      this.activityService
        .get(params['id'])
        .subscribe((data: ActivityModel) => {
          this.activity = data;

          this.citiesService.getCities().subscribe((cities: CityModel[]) => {
            this.city = cities.find((c) => c.id == this.activity.cityId);
          });
        });
    });
  }

  handleFileInput(file: FileList) {
    this.fileToUpload = file.item(0);

    let reader = new FileReader();
    reader.onload = (event: any) => {
      this.imageUrl = event.target.result;
    };
    reader.readAsDataURL(this.fileToUpload);
  }

  addPhoto() {
    this.fileToUpload = null;
    if (this.imageUrl != null) {

      this.photos.push(this.imageUrl);
      this.routeSub = this.activatedRoute.params.subscribe((params) => {
        this.photo.image = this.imageUrl.arrayBuffer;
        console.log(this.imageUrl);
        this.photosService
          .post(params['id'],this.photo)
          .subscribe((response) => {
            console.log(response.body);
          });
      });

      this.imageUrl = null;

    }
  }


  addComment() {
    console.log(this.comment);
    if (this.comment != '') {

      this.routeSub = this.activatedRoute.params.subscribe((params) => {
        this.formGroup.patchValue({ activityId: params['id'] });
        console.log(this.formGroup.getRawValue());
        this.commentsService
          .post(params['id'], this.formGroup.getRawValue())
          .subscribe((response) => {
            console.log(response.body);
            this.getComments(); //facem o noua cerere pt a aduce si noul comentariu
            this.isShowComments = true;
          });
      });
      this.formGroup.reset(); //stergem continutul din text area
    }
  }

  deleteComment(commentId) {
    this.routeSub = this.activatedRoute.params.subscribe((params) => {
      this.commentsService
        .delete(params['id'], commentId)
        .subscribe((response) => {
          this.getComments();
          this.isShowComments = true;
        });
    });
  }

  toggleShowComments() {
    if (!this.isShowComments) {
      this.getComments();
    }
    this.isShowComments = !this.isShowComments;
  }

  private getComments() {
    this.routeSub = this.activatedRoute.params.subscribe((params) => {
      this.commentsService
        .get(params['id'])
        .subscribe((data: CommentModel[]) => {
          this.comments = data;
        });
    });
  }


  ngOnDestroy(): void {
    this.routeSub.unsubscribe();
  }
}
