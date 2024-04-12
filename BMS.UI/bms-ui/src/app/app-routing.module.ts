import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookCategoriesListComponent } from './book-categories/book-categories-list/book-categories-list.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { AddBookCategoryComponent } from './book-categories/book-categories-list/add-book-category/add-book-category.component';
import { UpdateBookCategoryComponent } from './book-categories/book-categories-list/update-book-category/update-book-category.component';
import { DashboardComponent } from './dashboard/dashboard.component';


const routes: Routes = [
  {
    path: '',
    component: DashboardComponent,
  },
  {
    path: 'book-categories',
    component: BookCategoriesListComponent,
  },
  {
    path: 'book-categories/add',
    component: AddBookCategoryComponent,
  },
  {
    path: 'book-categories/edit/:id',
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
