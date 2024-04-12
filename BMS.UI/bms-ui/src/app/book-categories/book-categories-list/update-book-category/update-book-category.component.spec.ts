import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateBookCategoryComponent } from './update-book-category.component';

describe('UpdateBookCategoryComponent', () => {
  let component: UpdateBookCategoryComponent;
  let fixture: ComponentFixture<UpdateBookCategoryComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UpdateBookCategoryComponent]
    });
    fixture = TestBed.createComponent(UpdateBookCategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
