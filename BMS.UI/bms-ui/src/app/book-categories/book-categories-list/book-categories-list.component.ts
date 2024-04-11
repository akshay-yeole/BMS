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
  categoryName: string = '';
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

  addCategory() {
    // Add your logic here to handle adding the category, such as calling a service or emitting an event.
    console.log('Adding category:', this.categoryName);
    // You can also reset the categoryName if needed
    this.categoryName = '';
  }

}
