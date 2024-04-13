import { Injectable } from '@angular/core';
import { CommonHttpService } from './utils/http.service';
import { Observable } from 'rxjs';
import { Transaction } from '../models/transaction.model';

@Injectable({
  providedIn: 'root'
})
export class TransactionService extends CommonHttpService {
  url = 'https://localhost:7140/api';
  
  getAllTransaction() : Observable<Transaction[]>{
    return this.sendGetRequest<Transaction[]>(`${this.url}/LibraryTransactions`);
  }
}
