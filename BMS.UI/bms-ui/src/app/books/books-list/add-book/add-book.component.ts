import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookCategory } from 'src/app/core/models/book-category.model';
import { Book } from 'src/app/core/models/book.model';
import { BookCategoryService } from 'src/app/core/services/book-category.service';
import { BookService } from 'src/app/core/services/book.service';

@Component({
  selector: 'app-add-book',
  templateUrl: './add-book.component.html',
  styleUrls: ['./add-book.component.css'],
})
export class AddBookComponent implements OnInit {
  book: Book = {
    bookId: '00000000-0000-0000-0000-000000000000',
    bookName: '',
    author: '',
    copiesAvailable: 0,
    categoryid: '00000000-0000-0000-0000-000000000000',
  };
  categories: BookCategory[] = [];

  constructor(
    private categoryService: BookCategoryService,
    private bookService: BookService,
    private route: Router
  ) {}

  ngOnInit(): void {
    this.categoryService.getAllCategories().subscribe((data) => {
      this.categories = data;
    });
  }

  addBook() {
    this.bookService.addBook(this.book).subscribe(
      (data) => {
        this.route.navigate(['']);
      },
      (err) => {
        console.log(err);
      }
    );
  }
}
