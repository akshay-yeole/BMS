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
    id:'00000000-0000-0000-0000-000000000000',
    bookCode: '',
    studentId: '',
    issuedDate: null,
    returnedDate: new Date(1, 0, 1),
    expectedReturnedDate: null,
  };

  constructor(private transactionService: TransactionService) {}

  issueBook() {
    console.log('issue book', this.transaction);
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
