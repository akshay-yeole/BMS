import { Injectable } from "@angular/core";
import { CommonHttpService } from "./utils/http.service";
import { BookCategory } from "../models/book-category.model";
import { Observable } from "rxjs";

@Injectable({
    providedIn:'root'
})
export class BookCategoryService extends CommonHttpService {

    getAllCategories(){
        return this.sendGetRequest<BookCategory[]>(`${this.url}/BookCategories`);
    }

    getCategoryById(categoryId : string){
        return this.sendGetRequest<BookCategory>(`${this.url}/BookCategories/${categoryId}`);
    }

    addCategory(category : BookCategory) : Observable<boolean>{
        return this.sendPostRequest<boolean>(`${this.url}/BookCategories`, category);
    }

    deleteCategory(catgoryId : string) : Observable<boolean>{
        return this.sendDeleteRequest<boolean>(`${this.url}/BookCategories/${catgoryId}`);
    }

    updateCatgory(category : BookCategory) : Observable<boolean>{
        return this.sendPutRequest<boolean>(`${this.url}/BookCategories/${category.categoryId}`,category);
    }
}