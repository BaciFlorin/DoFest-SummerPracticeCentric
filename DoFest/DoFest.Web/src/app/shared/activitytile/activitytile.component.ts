import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-activitytile',
  templateUrl: './activitytile.component.html',
  styleUrls: ['./activitytile.component.scss']
})
export class ActivitytileComponent implements OnInit {

  @Input() public label: string = '';
  @Input() public background: string = '';
  @Input() public location: string = '';
  @Input() public inBucket: boolean = true;
  @Output() public goToAct: EventEmitter<string> = new EventEmitter();
  @Output() public addBucket: EventEmitter<string> = new EventEmitter();

  public hasPicture: boolean;

  ngOnInit(): void {
    if (this.background) {
      this.background = "url('" + this.background + "')";
    } else {
      this.background = "linear-gradient(to bottom right,#008080,#ADD8E6)";
    }
  }

  public addToBucket()
  {
    this.addBucket.emit("Add");
  }

  public goToActivity()
  {
    this.goToAct.emit("go");
  }
}

