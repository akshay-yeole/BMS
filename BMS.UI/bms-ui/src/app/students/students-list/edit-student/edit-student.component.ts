import { Component } from '@angular/core';
import { Student } from 'src/app/core/models/student.model';

@Component({
  selector: 'app-edit-student',
  templateUrl: './edit-student.component.html',
  styleUrls: ['./edit-student.component.css']
})
export class EditStudentComponent {
  student: Student = {
    id: '00000000-0000-0000-0000-000000000000',
    std: 0,
    div: '',
    rollNo: 0,
    name: '',
    address: '',
  };

  updateStudent(){}
}
