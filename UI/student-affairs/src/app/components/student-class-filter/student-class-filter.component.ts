import { Component, OnInit } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged,switchMap } from 'rxjs/operators';

import { StudentService } from '../../services/student.service';
import { Student } from '../../models/student.model';

@Component({
  selector: 'app-student-class-filter',
  templateUrl: './student-class-filter.component.html',
  styleUrls: ['./student-class-filter.component.css']
})
export class StudentClassFilterComponent implements OnInit {

  students$!: Observable<any>;
  private searchTerm=new Subject<string>();
  constructor(
    private studentService:StudentService
  ) { }

  search(term:string):void{
    this.searchTerm.next(term);
  }

  ngOnInit(): void {
    this.students$=this.searchTerm.pipe(
      // wait 300ms after each keystroke before considering the term
      debounceTime(300),

      // ignore new term if same as previous term
      distinctUntilChanged(),

      // switch to new search observable each time the term changes
      switchMap((term: string) => 
      this.studentService.getStudentsFilterByClassName(`?$filter=studentclass_name eq '${term}'`)
    ));
  }
}
