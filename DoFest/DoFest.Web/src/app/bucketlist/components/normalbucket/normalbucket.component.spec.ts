import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NormalbucketComponent } from './normalbucket.component';

describe('NormalbucketComponent', () => {
  let component: NormalbucketComponent;
  let fixture: ComponentFixture<NormalbucketComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NormalbucketComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NormalbucketComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
