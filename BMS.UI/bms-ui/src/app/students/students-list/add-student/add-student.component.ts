import { Component } from '@angular/core';
import { Student } from 'src/app/core/models/student.model';
import { StudentService } from 'src/app/core/services/student.service';

@Component({
  selector: 'app-add-student',
  templateUrl: './add-student.component.html',
  styleUrls: ['./add-student.component.css'],
})
export class AddStudentComponent {
  student: Student = {
    id: '00000000-0000-0000-0000-000000000000',
    std: 0,
    div: '',
    rollNo: 0,
    name: '',
    address: '',
  };
  standards: number[] = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
  divs: string[] = ['A', 'B', 'C', 'D'];

  constructor(private studentService: StudentService) {}

  addStudent() {
    this.studentService.addStudent(this.student).subscribe();
  }
}
