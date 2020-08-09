import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ActivitytileComponent } from './activitytile.component';

describe('ActivitytileComponent', () => {
  let component: ActivitytileComponent;
  let fixture: ComponentFixture<ActivitytileComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ActivitytileComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ActivitytileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
