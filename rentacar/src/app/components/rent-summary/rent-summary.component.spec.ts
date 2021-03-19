import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RentSummaryComponent } from './rent-summary.component';

describe('RentSummaryComponent', () => {
  let component: RentSummaryComponent;
  let fixture: ComponentFixture<RentSummaryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RentSummaryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RentSummaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
