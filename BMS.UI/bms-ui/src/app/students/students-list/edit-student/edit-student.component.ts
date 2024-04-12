import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Student } from 'src/app/core/models/student.model';
import { StudentService } from 'src/app/core/services/student.service';

@Component({
  selector: 'app-edit-student',
  templateUrl: './edit-student.component.html',
  styleUrls: ['./edit-student.component.css']
})
export class EditStudentComponent implements OnInit{
  
  student: Student = {
    id: '00000000-0000-0000-0000-000000000000',
    std: 0,
    div: '',
    rollNo: 0,
    name: '',
    address: '',
  };

  id:number=0;
  div: string='';
  rollNo: number=0;
  constructor(private studentService : StudentService,private route : ActivatedRoute){}

  ngOnInit(){
    this.route.params.subscribe(params => {
      this.id = params['id'];
      this.div = params['div'];
      this.rollNo = params['rollNo'];
    });
    this.studentService.getStudentDetails(this.id,this.div,this.rollNo).subscribe((data)=>{
      this.student =data;
    });
  }

  updateStudent(){}
}
