import { Component, OnInit } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged,switchMap } from 'rxjs/operators';
import { ActivatedRoute } from '@angular/router';

import { StudentSubjectList } from '../../models/student-subject.model';
import { StudentSubjectService } from '../../services/student-subject.service';

@Component({
  selector: 'app-student-subject',
  templateUrl: './student-subject.component.html',
  styleUrls: ['./student-subject.component.css']
})
export class StudentSubjectComponent implements OnInit {
  page: number = 1;
  count: number = 0;
  tableSize: number = 10;
  tableSizes: any = [3, 6, 9, 12];
  students$!: Observable<any>;
  students:StudentSubjectList[]=[];
  searchKey:string='';
  private searchTerm=new Subject<string>();
  constructor(private studentSubjectService :StudentSubjectService,
    private route: ActivatedRoute,) {
   }

  ngOnInit(): void {
    debugger;
    if(this.searchKey==''){
      this.getStudentSubjects();
    }else{
      this.students$=this.searchTerm.pipe(
        // wait 300ms after each keystroke before considering the term
        debounceTime(300),
  
        // ignore new term if same as previous term
        distinctUntilChanged(),
  
        // switch to new search observable each time the term changes
        switchMap((term: string) => 
        this.studentSubjectService.getStudentSubjectsFiltered(`?$filter=contains(Student_Name,'${term}') or contains(Subject_Name,'${term}')`)

        // this.studentSubjectService.getStudentSubjectsFiltered(`?$filter=Student_Name eq '${term}' or Subject_Name eq '${term}'`)
      ));
    }
    }
    
    getStudentSubjects():void{
      debugger;
      const id = Number(this.route.snapshot.paramMap.get('id'));
      if(id>0){
        this.studentSubjectService.getStudentSubjectsFiltered(`?$filter=Student_ID eq ${id}`)
        .subscribe((students:any)=>{
          this.students=students.value;
        });
      }else{
    this.studentSubjectService.getStudentSubjects()
    .subscribe((students:any)=>{
        this.students=students.value;
      });
    }
  }
  search(term:string):void{
    this.searchTerm.next(term);
    this.searchKey=term;
    this.studentSubjectService.getStudentSubjectsFiltered(`?$filter=contains(Student_Name,'${term}') or contains(Subject_Name,'${term}')`)
    .subscribe((students:any)=>{
      this.students=students.value;
    });
  }
  onTableDataChange(event: any) {
    this.page = event;
    this.getStudentSubjects();
  }
  onTableSizeChange(event: any): void {
    this.tableSize = event.target.value;
    this.page = 1;
    this.getStudentSubjects();
  }
}
