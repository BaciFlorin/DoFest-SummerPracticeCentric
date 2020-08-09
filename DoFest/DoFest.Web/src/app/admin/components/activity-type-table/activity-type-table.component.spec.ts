import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ActivityTypeTableComponent } from './activity-type-table.component';

describe('ActivityTypeTableComponent', () => {
  let component: ActivityTypeTableComponent;
  let fixture: ComponentFixture<ActivityTypeTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ActivityTypeTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ActivityTypeTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
