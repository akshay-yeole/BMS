import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
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

  constructor(private studentService: StudentService, private router: Router) {}

  addStudent() {
    this.studentService.add(this.student).subscribe(
      (data) => {
        this.router.navigate(['students']);
      },
      (err) => {
        console.log(err);
      }
    );
  }
}
