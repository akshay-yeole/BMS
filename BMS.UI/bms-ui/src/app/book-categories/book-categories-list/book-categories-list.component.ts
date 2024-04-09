import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs';
import { BookCategory } from 'src/app/core/models/book-category.model';
import { BookCategoryService } from 'src/app/core/services/book-category.service';

@Component({
  selector: 'app-book-categories-list',
  templateUrl: './book-categories-list.component.html',
  styleUrls: ['./book-categories-list.component.css']
})
export class BookCategoriesListComponent implements OnInit {
  bookCategories! : BookCategory[];
  
  constructor(private apiService : BookCategoryService) {
    
  }
  ngOnInit(): void {
    this.apiService.getAllBookCategories().pipe(
    ).subscribe(res => {
      console.log(res);
      this.bookCategories = res;
    });

    console.log(this.bookCategories);
  }

}
