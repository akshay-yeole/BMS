import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { BookCategory } from 'src/app/core/models/book-category.model';
import { BookCategoryService } from 'src/app/core/services/book-category.service';

@Component({
  selector: 'app-book-categories-list',
  templateUrl: './book-categories-list.component.html',
  styleUrls: ['./book-categories-list.component.css'],
})
export class BookCategoriesListComponent implements OnInit {
  bookCategories: BookCategory[] = [];
  category: BookCategory = { categoryId: '', categoryName: '' };

  constructor(
    private apiService: BookCategoryService,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.loadBookCategories();
  }

  loadBookCategories() {
    this.apiService.getAllCategories().subscribe((res) => {
      this.bookCategories = res;
    });
  }

  deleteCagetory(categoryId: string) {
    this.apiService.deleteCategory(categoryId).subscribe(() => {
      this.loadBookCategories();
      this.cdr.detectChanges();
    });
  }
}
