import { Component } from '@angular/core';
import { StudentService } from '../services/student.service';
import { Student } from '../models/student';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent {

  student: Student = {
    id: 0,
    name: '',
    age: 0,
    course: ''
  };

  constructor(public service: StudentService) {}

  addStudent() {
    this.service.addStudent({ ...this.student });

    this.student = {
      id: 0,
      name: '',
      age: 0,
      course: ''
    };
  }

  deleteStudent(id: number) {
    this.service.deleteStudent(id);
  }
}
