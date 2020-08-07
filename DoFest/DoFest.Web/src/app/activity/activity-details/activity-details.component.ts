import { Component, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';

import { ActivityService } from '../services/activity.service';
import { Subscription } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { ActivityModel } from '../models/activity.model';
import { CitiesService } from '../../shared/services/cities.service';
import { CommentsService } from '../services/comments.service';
import { PhotosService } from '../services/photos.service';
import { RatingsService } from '../services/ratings.service';
import { CityModel } from 'src/app/shared/models/city.model';
import { CommentModel } from '../models/comment.model';
import { PhotoModel } from '../models/photo.model';
import { HttpResponse } from '@angular/common/http';
import * as jwt_decode from 'jwt-decode';
import { RatingModel } from '../models/rating.model';

@Component({
  selector: 'app-activity-details',
  templateUrl: './activity-details.component.html',
  styleUrls: ['./activity-details.component.scss'],
  providers: [FormBuilder],
})
export class ActivityDetailsComponent implements OnInit, OnDestroy {
  fileToUpload: any;
  activity: ActivityModel;
  city: CityModel;
  formGroup: FormGroup;
  isShowPhotos: boolean;
  isShowComments: boolean;
  photos: PhotoModel[];
  comments: CommentModel[];
  photo: File;
  userId: string;
  rate: string;
  hasUserRated: boolean;
  userRating: string;

  @ViewChild('rating') rating: any;

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
    private ratingsService: RatingsService,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.formGroup = this.formBuilder.group({
      activityId: new FormControl(),
      content: new FormControl(),
    });

    this.isShowComments = false;
    this.isShowPhotos = false;
    this.hasUserRated = false;
    this.rate="No ratings yet";

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
    this.userId = jwt_decode(localStorage.getItem('userToken')).userId;
    this.calculateRating();
  }

  handleFileInput(file: FileList) {
    this.fileToUpload = file.item(0);
  }

  addPhoto() {
    var formData = new FormData();
    this.routeSub = this.activatedRoute.params.subscribe((params) => {
      formData.append('image', this.fileToUpload);

      this.photosService
        .post(params['id'], formData)
        .subscribe((res: HttpResponse<any>) => {
          console.log(res);
        });
    });
  }

  toggleShowPhotos() {
    if (!this.isShowPhotos) {
      this.getPhotos();
    }
    this.isShowPhotos = !this.isShowPhotos;
  }

  deletePhoto(photoId) {
    this.routeSub = this.activatedRoute.params.subscribe((params) => {
      this.photosService.delete(params['id'], photoId).subscribe((response) => {
        console.log(response);
        this.getPhotos();
        this.isShowPhotos = true;
      });
    });
  }

  addComment() {
    console.log(this.comment);
    if (this.comment != '') {
      this.routeSub = this.activatedRoute.params.subscribe((params) => {
        this.formGroup.patchValue({ activityId: params['id'] });

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

  private getPhotos() {
    this.routeSub = this.activatedRoute.params.subscribe((params) => {
      this.photosService.get(params['id']).subscribe((data: PhotoModel[]) => {
        this.photos = data;
      });
    });
  }

  private calculateRating() {
    this.routeSub = this.activatedRoute.params.subscribe((params) => {
      this.ratingsService.get(params['id']).subscribe((data: RatingModel[]) => {
        if(data.length){
        let calcRate = data
        .map((rating) => rating.stars)
        .reduce((sum, current) => sum + current);
      calcRate /= data.length;
      this.rate = calcRate.toFixed(2);
      let userRatingModel = data.find((r) => r.userId == this.userId);
      this.hasUserRated = userRatingModel != null;

      this.userRating = (this.hasUserRated)?userRatingModel.stars.toFixed(2):"You haven't rated yet";

        }
        else{
          this.rate="No ratings yet";
          this.userRating = "You haven't rated yet";
        }
      });
      this.rating.update(this.rate);
    });

  }

  saveRating(value) {
    if (!this.hasUserRated) {
      this.hasUserRated = true;
      this.userRating = value;
      this.routeSub = this.activatedRoute.params.subscribe((params) => {
        this.ratingsService
          .post(params['id'], JSON.stringify({ stars: value }))
          .subscribe((response) => {
            console.log(response);
          });
      });
    }
    this.calculateRating();
  }

  ngOnDestroy(): void {
    this.routeSub.unsubscribe();
  }
}
