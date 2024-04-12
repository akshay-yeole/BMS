import { Component } from '@angular/core';
import { Book } from 'src/app/core/models/book.model';
import { BookService } from 'src/app/core/services/book.service';

@Component({
  selector: 'app-books-list',
  templateUrl: './books-list.component.html',
  styleUrls: ['./books-list.component.css']
})
export class BooksListComponent {
  books: Book[] = [];

  constructor(
    private bookService: BookService
  ) {}

  ngOnInit(): void {
    this.loadBooks();
  }

  loadBooks() {
    this.bookService.getAllBooks().subscribe((res) => {
      this.books = res;
    });
  }

  deleteCagetory(bookId: string) {
    this.bookService.deleteBook(bookId).subscribe(() => {
      this.loadBooks();
    });
  }
}
