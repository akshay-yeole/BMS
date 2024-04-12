import { ChangeDetectorRef, Component } from '@angular/core';
import { Router } from '@angular/router';
import { BookCategory } from 'src/app/core/models/book-category.model';
import { BookCategoryService } from 'src/app/core/services/book-category.service';

@Component({
  selector: 'app-add-book-category',
  templateUrl: './add-book-category.component.html',
  styleUrls: ['./add-book-category.component.css']
})
export class AddBookCategoryComponent {
  category: BookCategory = { categoryId: '00000000-0000-0000-0000-000000000000', categoryName: '' };
  constructor(
    private apiService: BookCategoryService,
    private cdr: ChangeDetectorRef,
    private route : Router
  ) {}
  
  addCategory() {
    
    this.apiService.addCategory(this.category).subscribe((data) => {
      this.route.navigate(['']);
    },
    (err)=>{
      console.log(err); 
    }
  );
  }
}
