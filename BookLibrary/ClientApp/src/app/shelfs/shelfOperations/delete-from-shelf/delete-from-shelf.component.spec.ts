import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteFromShelfComponent } from './delete-from-shelf.component';

describe('DeleteFromShelfComponent', () => {
  let component: DeleteFromShelfComponent;
  let fixture: ComponentFixture<DeleteFromShelfComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeleteFromShelfComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeleteFromShelfComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
