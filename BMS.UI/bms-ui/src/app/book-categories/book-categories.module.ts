import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BookCategoriesListComponent } from './book-categories-list/book-categories-list.component';



@NgModule({
  declarations: [
    BookCategoriesListComponent
  ],
  imports: [
    CommonModule
  ],
  exports:[
    BookCategoriesListComponent
  ]
})
export class BookCategoriesModule { }
