import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BookCategory } from 'src/app/core/models/book-category.model';
import { Book } from 'src/app/core/models/book.model';
import { BookCategoryService } from 'src/app/core/services/book-category.service';
import { BookService } from 'src/app/core/services/book.service';

@Component({
  selector: 'app-update-book',
  templateUrl: './update-book.component.html',
  styleUrls: ['./update-book.component.css']
})
export class UpdateBookComponent {
  book: Book = {
    bookCode: '00000000-0000-0000-0000-000000000000',
    bookName: '',
    author: '',
    copiesAvailable: 0,
    categoryid: '00000000-0000-0000-0000-000000000000',
  };
  bookCode: string = '';
  categories: BookCategory[] = [];

  constructor(
    private categoryService: BookCategoryService,
    private bookService: BookService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      this.bookCode = params.get('id') ?? '';
    });

    this.bookService.getBookByBookCode(this.bookCode).subscribe((data) => {
      this.book = data;
    });

    this.categoryService.getAllCategories().subscribe((data) => {
      this.categories = data;
    });
  }

  updateBook(book: Book) {
    this.bookService.updateBook(book).subscribe(() => {
      this.router.navigate(['']);
    });
  }
}
