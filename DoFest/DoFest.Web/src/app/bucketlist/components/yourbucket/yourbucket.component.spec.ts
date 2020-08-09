import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { YourbucketComponent } from './yourbucket.component';

describe('YourbucketComponent', () => {
  let component: YourbucketComponent;
  let fixture: ComponentFixture<YourbucketComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ YourbucketComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(YourbucketComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
