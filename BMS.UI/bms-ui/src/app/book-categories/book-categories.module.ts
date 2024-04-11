import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BookCategoriesListComponent } from './book-categories-list/book-categories-list.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    BookCategoriesListComponent
  ],
  imports: [
    CommonModule,
    NgbModule,
    FormsModule 
  ],
  exports: [
    BookCategoriesListComponent 
  ]
})
export class BookCategoriesModule { }
