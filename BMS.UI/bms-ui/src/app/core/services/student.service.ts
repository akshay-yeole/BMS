import { Injectable } from '@angular/core';
import { CommonHttpService } from './utils/http.service';
import { Student } from '../models/student.model';

@Injectable({
  providedIn: 'root'
})
export class StudentService extends CommonHttpService {
  url ="https://localhost:7140/api";

  getAllStudents(){
    return this.sendGetRequest<Student[]>(`${this.url}/Students`);
  }
}
