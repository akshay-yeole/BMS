import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Transaction } from 'src/app/core/models/transaction.model';
import { TransactionService } from 'src/app/core/services/transaction.service';

@Component({
  selector: 'app-returned-book',
  templateUrl: './returned-book.component.html',
  styleUrls: ['./returned-book.component.css']
})
export class ReturnedBookComponent implements OnInit {

  transaction: Transaction = {
    id:'',
    bookCode: '',
    studentId: '',
    issuedDate: new Date(),
    returnedDate: new Date(),
    expectedReturnedDate: null,
  };

  constructor(private transactionService: TransactionService, private route : ActivatedRoute, private router : Router) {
    
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      this.transaction.id = params.get('id') ?? '';
    });

    this.transactionService.getTransactionById(this.transaction.id).subscribe((data) => {
      this.transaction = data;
      console.log('get data', data);
    });

  }

  ReturnedBook(){
    this.transactionService.returnBook(this.transaction).subscribe(() => {
      this.router.navigate(['']);
    });
  }

}
