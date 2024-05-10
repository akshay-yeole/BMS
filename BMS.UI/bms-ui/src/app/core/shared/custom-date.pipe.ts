import { DatePipe } from '@angular/common';
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'customDate'
})
export class CustomDatePipe implements PipeTransform {

  transform(value: Date | null): string {
    if (!value) {
      return ''; // Handle null or undefined value
    }
    
    const datePipe: DatePipe = new DatePipe('en-US');
    return datePipe.transform(value, 'yyyy-MM-dd') || ''; // Adjust the date format as per your requirement
  }
}