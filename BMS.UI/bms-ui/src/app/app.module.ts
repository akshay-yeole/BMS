import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { HttpClientModule } from '@angular/common/http';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';
import { BookCategoriesListComponent } from './book-categories/book-categories-list/book-categories-list.component';
import { AddBookCategoryComponent } from './book-categories/book-categories-list/add-book-category/add-book-category.component';
import { UpdateBookCategoryComponent } from './book-categories/book-categories-list/update-book-category/update-book-category.component';
import { BooksListComponent } from './books/books-list/books-list.component';
import { AddBookComponent } from './books/books-list/add-book/add-book.component';
import { UpdateBookComponent } from './books/books-list/update-book/update-book.component';
import { StudentsListComponent } from './students/students-list/students-list.component';
import { AddStudentComponent } from './students/students-list/add-student/add-student.component';
import { EditStudentComponent } from './students/students-list/edit-student/edit-student.component';
import { TransactionListComponent } from './transactions/transaction-list/transaction-list.component';
import { IssueBookComponent } from './transactions/transaction-list/issue-book/issue-book.component';
@NgModule({
  declarations: [
    AppComponent,
    NotFoundComponent,
    HeaderComponent,
    FooterComponent,
    SidebarComponent,
    DashboardComponent,
    BookCategoriesListComponent,
    AddBookCategoryComponent,
    UpdateBookCategoryComponent,
    BooksListComponent,
    AddBookComponent,
    UpdateBookComponent,
    StudentsListComponent,
    AddStudentComponent,
    EditStudentComponent,
    TransactionListComponent,
    IssueBookComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgbModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
