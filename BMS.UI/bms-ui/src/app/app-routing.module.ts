import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookCategoriesListComponent } from './book-categories/book-categories-list/book-categories-list.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { AddBookCategoryComponent } from './book-categories/book-categories-list/add-book-category/add-book-category.component';
import { UpdateBookCategoryComponent } from './book-categories/book-categories-list/update-book-category/update-book-category.component';


const routes: Routes = [
  {
    path: '',
    component: BookCategoriesListComponent,
  },
  {
    path: 'add-category',
    component: AddBookCategoryComponent,
  },
  {
    path: 'edit-category/:id',
    component: UpdateBookCategoryComponent,
  },
  {
    path:'**', component: NotFoundComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
