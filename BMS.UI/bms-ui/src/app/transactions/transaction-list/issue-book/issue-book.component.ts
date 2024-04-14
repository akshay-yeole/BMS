import { Component } from '@angular/core';
import { Transaction } from 'src/app/core/models/transaction.model';
import { TransactionService } from 'src/app/core/services/transaction.service';

@Component({
  selector: 'app-issue-book',
  templateUrl: './issue-book.component.html',
  styleUrls: ['./issue-book.component.css'],
})
export class IssueBookComponent {
  transaction: Transaction = {
    bookCode: '',
    studentId: '',
    issuedDate: null,
    returnedDate: null,
    expectedReturnedDate: null,
  };

  constructor(private transactionService: TransactionService) {}

  issueBook() {
    this.transactionService.issueBook(this.transaction).subscribe(
      (data) => {
        console.log('data', data);
      },
      (err) => {
        console.log(err);
      }
    );
  }
}
