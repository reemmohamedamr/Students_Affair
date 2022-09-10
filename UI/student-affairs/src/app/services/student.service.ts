import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Student } from '../models/student.model';
import { MessageService } from './message.service';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  private getStudentsUrl = 'https://localhost:44323/odata/studentodata';
  private initStudentUrl='https://localhost:44323/api/student/AddStudent';
  private getStudentUrl = 'https://localhost:44323/api/student/GetStudent';
  private addStudentUrl = 'https://localhost:44323/api/student/AddStudent';
  private updateStudentUrl = 'https://localhost:44323/api/student/UpdateStudent';
  private deleteStudentUrl = 'https://localhost:44323/api/student/DeleteStudent';
  private getStudentsFilteredByClassNameUrl = 'https://localhost:44323/api/student/GetStudentsFilteredByClassName';
  httpOptions={
    headers: new HttpHeaders({'Content-Type':'application/json'})
  };

  students: Student[] = [];
  constructor(
    private http: HttpClient,
    private messageService: MessageService
  ) { }
  getStudents(): Observable<Student[]> {
    return this.http.get<Student[]>(this.getStudentsUrl)
      .pipe(
        tap(_=> this.log('Fetched Students')),
        catchError(this.handleError<Student[]>('getStudents', []))
      );
  }
  getStudentsFilterByClassName(filter:string): Observable<Student[]> {
    return this.http.get<Student[]>(`${this.getStudentsUrl}${filter}`)
      .pipe(
        tap(_=> this.log('Fetched Students')),
        catchError(this.handleError<Student[]>('getStudentsFilterByClassName', []))
      );
  }
  getStudent(id: number): Observable<Student> {
    return this.http.get<Student>(`${this.getStudentUrl}/${id}`)
    .pipe(
      tap(_=>this.log(`Fetched Student id=${id}`)),
      catchError(this.handleError<Student>(`getStudent id=${id}`))
    );
  }
  initStudent():Observable<Student>{
    return this.http.get<Student>(this.initStudentUrl)
    .pipe(
      tap((newStudent:Student)=>this.log(`added student w/ id= ${newStudent.student_ID}`)),
      catchError(this.handleError<Student>('Add Student'))
    );
  }
  addStudent(student:Student):Observable<Student>{
    return this.http.post<Student>(this.addStudentUrl,student,this.httpOptions)
    .pipe(
      tap((newStudent:Student)=>this.log(`added student w/ id= ${newStudent.student_ID}`)),
      catchError(this.handleError<Student>('Add Student'))
    );
  }
  updateStudent(student:Student):Observable<any>{
    return this.http.put(this.updateStudentUrl,student,this.httpOptions)
    .pipe(
      tap(_=>this.log(`updated student id= ${student.student_ID}`)),
      catchError(this.handleError<any>('update Student'))
    );
  }
  deleteStudent(id:number):Observable<Student>{
    return this.http.delete<Student>(`${this.deleteStudentUrl}/${id}`,this.httpOptions)
    .pipe(
      tap(_=>this.log(`deleted student id= ${id}`)),
      catchError(this.handleError<Student>('delete Student'))
    );
  }
  filterByClassName(term: string): Observable<Student[]> {
    if (!term.trim()) {
      // if not search term, return empty student array.
      return of([]);
    }
    return this.http.get<Student[]>(`${this.getStudentsFilteredByClassNameUrl}/${term}`).pipe(
      tap(x => x.length ?
        this.log(`found students matching "${term}"`) :
        this.log(`no students matching "${term}"`)),
      catchError(this.handleError<Student[]>('search students', []))
    );
  }
  private log(message: string) {
    this.messageService.add(`Student: ${message}`);
  }
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
