import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteauthorComponent } from './deleteauthor.component';

describe('DeleteauthorComponent', () => {
  let component: DeleteauthorComponent;
  let fixture: ComponentFixture<DeleteauthorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeleteauthorComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeleteauthorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
