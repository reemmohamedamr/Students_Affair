import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';

import { StudentSubject,StudentSubjectList } from '../models/student-subject.model';

@Injectable({
  providedIn: 'root'
})
export class StudentSubjectService {
  private getStudentSubjectsUrl = 'https://localhost:44323/odata/StudentSubjectOData';
  httpOptions={
  headers: new HttpHeaders({'Content-Type':'application/json'})
};
constructor(
  private http: HttpClient
) { }
getStudentSubjects(): Observable<StudentSubject[]> {
  return this.http.get<StudentSubject[]>(this.getStudentSubjectsUrl)
    .pipe();
}
getStudentSubjectsFiltered(filter:string): Observable<StudentSubjectList[]> {
  return this.http.get<StudentSubjectList[]>(`${this.getStudentSubjectsUrl}${filter}`)
    .pipe();
}
}
