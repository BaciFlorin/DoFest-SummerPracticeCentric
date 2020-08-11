import {
  AfterViewInit,
  ChangeDetectorRef,
  Component,
  OnInit,
  Output,
  EventEmitter,
} from '@angular/core';
import { Router } from '@angular/router';

import { UserService } from '../services';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent implements OnInit {
  public username: string;
  @Output() private profileCLick: EventEmitter<string>;

  constructor(
    private readonly router: Router,
    private readonly cdRef: ChangeDetectorRef,
    public readonly userService: UserService
  ) {
    this.profileCLick = new EventEmitter<string>();
  }
  ngOnInit(): void {
    this.getUserName();
  }

  public logout(): void {
    this.router.navigate(['authentication']);
    sessionStorage.clear();
  }

  public onProfileClick() {
    this.router.navigate(['userInfo']);
  }

  public getUserName(): void {
    if (sessionStorage.getItem('identity') != null)
      this.userService.username = JSON.parse(
        sessionStorage.getItem('identity')
      )['username'];
    this.username = this.userService.username;
  }
}
