import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BookCategory } from 'src/app/core/models/book-category.model';
import { BookCategoryService } from 'src/app/core/services/book-category.service';

@Component({
  selector: 'app-update-book-category',
  templateUrl: './update-book-category.component.html',
  styleUrls: ['./update-book-category.component.css']
})
export class UpdateBookCategoryComponent implements OnInit{
  category: BookCategory = { categoryId: '00000000-0000-0000-0000-000000000000', categoryName: '' };
  categoryId : string='';
  constructor(
    private apiService: BookCategoryService,
    private router : Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.categoryId = params.get('id') ??'';
    });

    this.apiService.getCategoryById(this.categoryId).subscribe(
      (data)=>{this.category =data;}
    );
  }

  updateCagetory(category: BookCategory) {
    this.apiService.updateCatgory(category).subscribe(() => {
      this.router.navigate(['']);
    });
  }
}
