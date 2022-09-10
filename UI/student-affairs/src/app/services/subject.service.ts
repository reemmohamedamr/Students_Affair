import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';

import { StudentSubject } from '../models/student-subject.model';

@Injectable({
  providedIn: 'root'
})
export class SubjectService {
  private getSubjectsUrl = 'https://localhost:44323/api/Subject';
httpOptions={
  headers: new HttpHeaders({'Content-Type':'application/json'})
};
constructor(
  private http: HttpClient
) { }
getSubjects(): Observable<StudentSubject[]> {
  return this.http.get<StudentSubject[]>(this.getSubjectsUrl)
    .pipe();
}
}
