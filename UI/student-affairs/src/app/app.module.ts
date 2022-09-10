import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common'; 
import { FormsModule, ReactiveFormsModule} from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';

import {NgxPaginationModule} from 'ngx-pagination';  
import { Ng2SearchPipeModule } from 'ng2-search-filter';  

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';

import { StudentsComponent } from './components/students/list-student/students.component';
import { StudentSubjectComponent } from './components/student-subject/student-subject.component';
import { MessagesComponent } from './components/messages/messages.component';
import { StudentClassFilterComponent } from './components/student-class-filter/student-class-filter.component';
import { AddStudentComponent } from './components/students/add-student/add-student.component';


@NgModule({
  declarations: [
    AppComponent,
    StudentsComponent,
    StudentSubjectComponent,
    MessagesComponent,
    StudentClassFilterComponent,
    AddStudentComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgxPaginationModule,
    Ng2SearchPipeModule,
    NgMultiSelectDropDownModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
