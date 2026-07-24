import { Injectable } from '@angular/core';
import { Student } from '../models/student';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  students: Student[] = [];

  getStudents() {
    return this.students;
  }

  addStudent(student: Student) {
    this.students.push(student);
  }

  deleteStudent(id: number) {
    this.students = this.students.filter(s => s.id !== id);
  }
}
