import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { map } from 'rxjs';
import { BookCategory } from 'src/app/core/models/book-category.model';
import { BookCategoryService } from 'src/app/core/services/book-category.service';

@Component({
  selector: 'app-book-categories-list',
  templateUrl: './book-categories-list.component.html',
  styleUrls: ['./book-categories-list.component.css']
})
export class BookCategoriesListComponent implements OnInit {
  bookCategories: BookCategory[] = [];
  newCategoryName : any;
  constructor(private modalService: NgbModal, private apiService: BookCategoryService) { }

  ngOnInit(): void {
    this.loadBookCategories();
  }

  loadBookCategories() {
    this.apiService.getAllBookCategories().subscribe(res => {
      this.bookCategories = res;
    });
  }

  saveCategory(){

  }

}
