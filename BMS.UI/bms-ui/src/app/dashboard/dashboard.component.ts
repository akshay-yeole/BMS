import { Component } from '@angular/core';
import Chart from 'chart.js/auto';
import { BookCategoryService } from '../core/services/book-category.service';
import { map } from 'rxjs';
import { BookService } from '../core/services/book.service';
import { StudentService } from '../core/services/student.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
})
export class DashboardComponent {
  categoryCount: number = 0;
  studentsCount: number = 0;
  booksCount: number = 0;
  transactionCount: number = 0;
  cards: { title: string; content: any; link: string }[] = [];

  constructor(
    private studentService : StudentService,
    private catgeoryService: BookCategoryService,
    private bookService: BookService
  ) {}

  ngOnInit(): void {
    this.renderDetails();
  }

  renderDetails() {
    this.catgeoryService
      .getAllCategories()
      .pipe(
        map((data) => data.length) // Map the array to its length
      )
      .subscribe((count) => {
        this.categoryCount = count;
        this.updateCards();
      });

    this.bookService
      .getAllBooks()
      .pipe(
        map((data) => data.length) // Map the array to its length
      )
      .subscribe((count) => {
        this.booksCount = count;
        this.updateCards();
      });

      this.studentService.getAllStudents()
      .pipe(
        map((data) => data.length) // Map the array to its length
      )
      .subscribe((count) => {
        this.studentsCount = count;
        this.updateCards();
      });
;
  }

  updateCards(): void {
    this.cards = [
      {
        title: 'Book Categories',
        content: this.categoryCount,
        link: 'book-categories',
      },
      {
        title: 'Books',
        content: this.booksCount,
        link: 'books',
      },
      {
        title: 'Students',
        content: this.studentsCount,
        link: 'students',
      },
      {
        title: 'Transactions',
        content: this.transactionCount,
        link: 'transaction',
      },
    ];
  }
}
