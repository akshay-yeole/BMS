import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookCategoriesListComponent } from './book-categories/book-categories-list/book-categories-list.component';
import { NotFoundComponent } from './not-found/not-found.component';

const routes: Routes = [
  {
    path: '',
    component: BookCategoriesListComponent,
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
