import { Component, OnInit } from '@angular/core';
import { NotificationService } from '../services/notification.service';
import { NotificationModel } from '../models/notification.model';
import { range } from 'rxjs';
@Component({
  selector: 'app-notifications',
  templateUrl: './notifications.component.html',
  styleUrls: ['./notifications.component.scss'],
})
export class NotificationsComponent implements OnInit {
  public notifications: NotificationModel[];

  constructor(private readonly notificationService: NotificationService) {}

  ngOnInit(): void {
    this.notificationService.getAll().subscribe((data: NotificationModel[]) => {
      this.notifications = data.sort(
        (a, b) => new Date(b.date).getTime() - new Date(a.date).getTime()
      );
    });
  }

  getPromptDate(dateString: string): string {
    let date = new Date(dateString);
    return `${date.getDay()}.${date.getMonth()}.${date.getFullYear()} ${date.getHours()}:${
      date.getMinutes() < 10
        ? '0' + date.getMinutes().toString()
        : date.getMinutes()
    }`;
  }
}
