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

  add(data: Student): Observable<boolean> {
    return this.sendPostRequest<boolean>(`${this.url}/Students`, data);
  }

  getStudentDetails(std: number, div: string, rollNo: number) {
    return this.sendGetRequest<Student>(
      `${this.url}/Students/${std}/${div}/${rollNo}`
    );
  }

  update(model: Student): Observable<boolean> {
    return this.sendPutRequest<boolean>(
      `${this.url}/Students/${model.id}`,
      model
    );
  }

  delete(studentId: string) : Observable<boolean>{
    return this.sendDeleteRequest<boolean>(`${this.url}/Students/${studentId}`);
}
}
