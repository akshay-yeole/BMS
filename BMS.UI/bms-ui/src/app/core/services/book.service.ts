import { Injectable } from '@angular/core';
import { Book } from '../models/book.model';
import { CommonHttpService } from './utils/http.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BookService extends CommonHttpService {

  getAllBooks(){
      return this.sendGetRequest<Book[]>(`${this.url}/Books`);
  }

  getBookByBookCode(bookCode : string){
      return this.sendGetRequest<Book>(`${this.url}/Books/${bookCode}`);
  }

  addBook(book : Book) : Observable<boolean>{
      return this.sendPostRequest<boolean>(`${this.url}/Books`, book);
  }

  deleteBook(bookCode : string) : Observable<boolean>{
      return this.sendDeleteRequest<boolean>(`${this.url}/Books/${bookCode}`);
  }

  updateBook(book : Book) : Observable<boolean>{
      return this.sendPutRequest<boolean>(`${this.url}/Books/${book.bookCode}`,book);
  }
}
