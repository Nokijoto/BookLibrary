import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateshelfComponent } from './updateshelf.component';

describe('UpdateshelfComponent', () => {
  let component: UpdateshelfComponent;
  let fixture: ComponentFixture<UpdateshelfComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateshelfComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpdateshelfComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
