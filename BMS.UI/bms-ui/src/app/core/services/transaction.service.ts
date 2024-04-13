import { Injectable } from '@angular/core';
import { CommonHttpService } from './utils/http.service';
import { Observable } from 'rxjs';
import { Transaction } from '../models/transaction.model';

@Injectable({
  providedIn: 'root',
})
export class TransactionService extends CommonHttpService {
  getAllTransaction(): Observable<Transaction[]> {
    return this.sendGetRequest<Transaction[]>(
      `${this.url}/LibraryTransactions`
    );
  }

  issueBook(model: Transaction): Observable<boolean> {
    console.log(`${this.url}/LibraryTransactions/issue-book`);
    return this.sendPostRequest<boolean>(
      `${this.url}/LibraryTransactions/issue-book`,
      model
    );
  }
}
