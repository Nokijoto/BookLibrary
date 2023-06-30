import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddToShelfComponent } from './add-to-shelf.component';

describe('AddToShelfComponent', () => {
  let component: AddToShelfComponent;
  let fixture: ComponentFixture<AddToShelfComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddToShelfComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddToShelfComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
