import { Component, OnInit } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged,switchMap } from 'rxjs/operators';

import { StudentList } from '../../../models/student-list.model';
import { StudentService } from '../../../services/student.service';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.css']
})
export class StudentsComponent implements OnInit {
  page: number = 1;
  count: number = 0;
  tableSize: number = 10;
  tableSizes: any = [3, 6, 9, 12];
  students$!: Observable<any>;
  students:StudentList[]=[];
  searchKey:string='';
  private searchTerm=new Subject<string>();
  constructor(private studentService :StudentService) {
   }

  ngOnInit(): void {
    debugger;
    if(this.searchKey==''){
      this.getStudents();
    }else{
      this.students$=this.searchTerm.pipe(
        // wait 300ms after each keystroke before considering the term
        debounceTime(300),
  
        // ignore new term if same as previous term
        distinctUntilChanged(),
  
        // switch to new search observable each time the term changes
        switchMap((term: string) => 
        this.studentService.getStudentsFilterByClassName(`?$filter=contains(studentclass_name,'${term}')`)

      ));
    }
    }
    
    getStudents():void{
      debugger;
    this.studentService.getStudents()
    .subscribe((students:any)=>{
        this.students=students.value;
      });
  }
  search(term:string):void{
    debugger;
    this.searchTerm.next(term);
    this.searchKey=term;
    this.studentService.getStudentsFilterByClassName(`?$filter=contains(studentclass_name,'${term}')`)
    .subscribe((students:any)=>{
      this.students=students.value;
    });
  }
  onTableDataChange(event: any) {
    this.page = event;
    this.getStudents();
  }
  onTableSizeChange(event: any): void {
    this.tableSize = event.target.value;
    this.page = 1;
    this.getStudents();
  }
  delete(st: StudentList): void {
    this.students = this.students.filter(h => h !== st);
    this.studentService.deleteStudent(st.Student_ID).subscribe();
  }
}
