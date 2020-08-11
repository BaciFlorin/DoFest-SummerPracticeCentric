import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommentModel } from '../models/comment.model';
import { CreateCommentModel } from '../models/createcomment.model';
import { Observable } from 'rxjs';
import { RouteService } from 'src/app/shared/services/route.service';

@Injectable({
  providedIn: 'root',
})
export class CommentsService {
  constructor(
    private readonly http: HttpClient,
    private readonly routeService: RouteService
  ) {}

  get(id: string): Observable<CommentModel[]> {
    return this.http.get<CommentModel[]>(
      this.routeService.getRoute('comment', 'get all', id)
    );
  }

  delete(activityId: string, commentId: string): Observable<any> {
    return this.http.delete<any>(
      this.routeService.getRoute('comment', 'delete', activityId, commentId)
    );
  }

  post(activityId: string, comment: CreateCommentModel): Observable<any> {
    return this.http.post<any>(
      this.routeService.getRoute('comment', 'add one', activityId),
      comment
    );
  }
}
