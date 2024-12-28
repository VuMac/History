import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LambaithiComponent } from './lambaithi.component';

describe('LambaithiComponent', () => {
  let component: LambaithiComponent;
  let fixture: ComponentFixture<LambaithiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LambaithiComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LambaithiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
