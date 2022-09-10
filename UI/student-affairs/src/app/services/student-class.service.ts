import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';

import { StudentClass } from '../models/student-class.model';

@Injectable({
  providedIn: 'root'
})
export class StudentClassService {
  private getStudentClassesUrl = 'https://localhost:44323/api/StudentClass';
  httpOptions={
    headers: new HttpHeaders({'Content-Type':'application/json'})
  };
  constructor(
    private http: HttpClient
  ) { }
  getStudentClasses(): Observable<StudentClass[]> {
    return this.http.get<StudentClass[]>(this.getStudentClassesUrl)
      .pipe();
  }
}
