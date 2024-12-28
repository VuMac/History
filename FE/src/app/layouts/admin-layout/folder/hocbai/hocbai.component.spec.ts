import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HocbaiComponent } from './hocbai.component';

describe('HocbaiComponent', () => {
  let component: HocbaiComponent;
  let fixture: ComponentFixture<HocbaiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HocbaiComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HocbaiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
