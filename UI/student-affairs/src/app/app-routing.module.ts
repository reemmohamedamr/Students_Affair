import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { StudentsComponent } from './components/students/list-student/students.component';
import { AddStudentComponent } from './components/students/add-student/add-student.component';
import { StudentSubjectComponent } from './components/student-subject/student-subject.component';


const routes: Routes = [
  { path: '', redirectTo: '/students', pathMatch: 'full' },
  { path: 'studentsubject/:id', component: StudentSubjectComponent },
  { path: 'details/:id', component: AddStudentComponent },
  { path: 'addstudent/:id', component: AddStudentComponent },
  { path: 'addstudent', component: AddStudentComponent },
  { path: 'studentSubjects', component: StudentSubjectComponent },
  { path: 'students', component: StudentsComponent }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes),
    CommonModule,
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
