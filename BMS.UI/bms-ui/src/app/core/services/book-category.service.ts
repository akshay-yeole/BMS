import { Injectable } from "@angular/core";
import { CommonHttpService } from "./utils/http.service";
import { BookCategory } from "../models/book-category.model";

@Injectable({
    providedIn:'root'
})
export class BookCategoryService {
    url ="https://localhost:7140/api";
    constructor(private httpService : CommonHttpService) {
    }

    getAllBookCategories(){
        return this.httpService.sendGetRequest<BookCategory>(`${this.url}/BookCategories`);
    }
}