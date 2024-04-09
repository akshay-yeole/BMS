import { Component, OnInit } from '@angular/core';
import { BookCategoryService } from './core/services/book-category.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'bms-ui';
  constructor(private bookCategoryService : BookCategoryService) {
    
  }
  ngOnInit(): void {
    this.bookCategoryService.getAllBookCategories().subscribe(data => console.log(data));
  }

  
}
