import { Injectable } from '@angular/core';
import { CommonHttpService } from './utils/http.service';
import { Student } from '../models/student.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class StudentService extends CommonHttpService {
  url = 'https://localhost:7140/api';

  getAllStudents(): Observable<Student[]> {
    return this.sendGetRequest<Student[]>(`${this.url}/Students`);
  }

  addStudent(data: Student): Observable<boolean> {
    return this.sendPostRequest<boolean>(`${this.url}/Students`, data);
  }
}
