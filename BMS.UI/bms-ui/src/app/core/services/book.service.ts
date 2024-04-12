import { Injectable } from '@angular/core';
import { Book } from '../models/book.model';
import { CommonHttpService } from './utils/http.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BookService extends CommonHttpService {
  url ="https://localhost:7140/api";

  getAllBooks(){
      return this.sendGetRequest<Book[]>(`${this.url}/Books`);
  }

  getBookById(bookId : string){
      return this.sendGetRequest<Book>(`${this.url}/Books/${bookId}`);
  }

  addBook(book : Book) : Observable<boolean>{
      return this.sendPostRequest<boolean>(`${this.url}/Books`, book);
  }

  deleteBook(bookId : string) : Observable<boolean>{
      return this.sendDeleteRequest<boolean>(`${this.url}/Books/${bookId}`);
  }

  updateBook(book : Book) : Observable<boolean>{
      return this.sendPutRequest<boolean>(`${this.url}/Books/${book.bookId}`,book);
  }
}
