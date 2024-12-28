import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChamdiemComponent } from './chamdiem.component';

describe('ChamdiemComponent', () => {
  let component: ChamdiemComponent;
  let fixture: ComponentFixture<ChamdiemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ChamdiemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ChamdiemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
