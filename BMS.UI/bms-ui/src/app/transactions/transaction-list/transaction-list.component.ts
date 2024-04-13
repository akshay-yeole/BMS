import { Component, OnInit } from '@angular/core';
import { Transaction } from 'src/app/core/models/transaction.model';
import { TransactionService } from 'src/app/core/services/transaction.service';

@Component({
  selector: 'app-transaction-list',
  templateUrl: './transaction-list.component.html',
  styleUrls: ['./transaction-list.component.css'],
})
export class TransactionListComponent implements OnInit {
  transactions: Transaction[] = [];

  constructor(private transactionService : TransactionService) { }
  
  ngOnInit() {
    this.transactionService.getAllTransaction().subscribe((data)=>{
      this.transactions =data;
    },
  (err)=>{
    alert(err.message);
  });
  }


}
