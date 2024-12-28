import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QuanlycauhoiComponent } from './quanlycauhoi.component';

describe('QuanlycauhoiComponent', () => {
  let component: QuanlycauhoiComponent;
  let fixture: ComponentFixture<QuanlycauhoiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QuanlycauhoiComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(QuanlycauhoiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
