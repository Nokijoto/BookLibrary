import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShelfsdetailsComponent } from './shelfsdetails.component';

describe('ShelfsdetailsComponent', () => {
  let component: ShelfsdetailsComponent;
  let fixture: ComponentFixture<ShelfsdetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShelfsdetailsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShelfsdetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
