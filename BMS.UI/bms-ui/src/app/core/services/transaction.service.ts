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

  getTransactionById(transactionId : string){
    return this.sendGetRequest<Transaction>(
      `${this.url}/LibraryTransactions/${transactionId}`
    );
}

  issueBook(model: Transaction): Observable<boolean> {
    return this.sendPostRequest<boolean>(
      `${this.url}/LibraryTransactions/issue-book`,
      model
    );
  }

  returnBook(model: Transaction) : Observable<boolean>{
    return this.sendPutRequest<boolean>(
      `${this.url}/LibraryTransactions/return-book/${model.id}`,
      model
    );
  }
}
