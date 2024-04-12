import { Component, OnInit } from '@angular/core';
import { Student } from 'src/app/core/models/student.model';
import { StudentService } from 'src/app/core/services/student.service';

@Component({
  selector: 'app-students-list',
  templateUrl: './students-list.component.html',
  styleUrls: ['./students-list.component.css'],
})
export class StudentsListComponent implements OnInit {
  students: Student[] = [];

  constructor(private studentService: StudentService) {}

  ngOnInit(): void {
    this.studentService.getAllStudents().subscribe(
      (data) => {
        this.students = data;
      },
      (err) => {
        console.log(err);
      }
    );
  }

  deleteStudent(std: number, rollNo : number, div: string){

  }
}
