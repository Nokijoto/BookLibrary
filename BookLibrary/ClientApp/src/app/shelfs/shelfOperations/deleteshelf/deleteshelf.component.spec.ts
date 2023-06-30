import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteshelfComponent } from './deleteshelf.component';

describe('DeleteshelfComponent', () => {
  let component: DeleteshelfComponent;
  let fixture: ComponentFixture<DeleteshelfComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeleteshelfComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeleteshelfComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
