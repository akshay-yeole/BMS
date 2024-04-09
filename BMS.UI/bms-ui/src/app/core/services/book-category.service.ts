import { Injectable } from "@angular/core";
import { CommonHttpService } from "./utils/http.service";
import { BookCategory } from "../models/book-category.model";

@Injectable({
    providedIn:'root'
})
export class BookCategoryService extends CommonHttpService {
    url ="https://localhost:7140/api";

    getAllBookCategories(){
        return this.sendGetRequest<BookCategory[]>(`${this.url}/BookCategories`);
    }
}