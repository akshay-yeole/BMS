import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddBookCategoryComponent } from './add-book-category.component';

describe('AddBookCategoryComponent', () => {
  let component: AddBookCategoryComponent;
  let fixture: ComponentFixture<AddBookCategoryComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddBookCategoryComponent]
    });
    fixture = TestBed.createComponent(AddBookCategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
