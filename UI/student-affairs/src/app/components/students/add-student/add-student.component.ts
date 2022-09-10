import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { FormGroup } from '@angular/forms';
import { FormBuilder, Validators } from '@angular/forms';
import { IDropdownSettings, } from 'ng-multiselect-dropdown';
import { filter } from 'rxjs/operators';

import { Student } from 'src/app/models/student.model';
import { StudentClass } from 'src/app/models/student-class.model';
import { StudentSubject } from 'src/app/models/student-subject.model';
import { StudentService } from 'src/app/services/student.service';
import { StudentClassService } from 'src/app/services/student-class.service';
import { SubjectService } from 'src/app/services/subject.service';

@Component({
  selector: 'app-add-student',
  templateUrl: './add-student.component.html',
  styleUrls: ['./add-student.component.css'],
  providers: [StudentClassService]
})
export class AddStudentComponent implements OnInit {


  student_Name_Error: boolean = false;
  student_Address_Error: boolean = false;
  student_EmailAddress_Error: boolean = false;
  student_BirthDate_Error: boolean = false;
  student_Class_Error: boolean = false;
  student_Subject_Error: boolean = false;


  isViewMode: boolean = false;
  dropdownSettings: IDropdownSettings = {};
  selectedItems: any = [];
  dropDownForm: FormGroup | undefined;
  student: Student = {
    student_ID: 0,
    studentClass_ID: 0,
    student_Name: '',
    studentClass_Name: '',
    student_Address: '',
    student_BirthDate: new Date(),
    student_EmailAddress: '',
    classesList: [],
    studentClass: {
      studentClass_ID: 0,
      studentClass_Name: ''
    },
    studentSubjectsList: [],
    subjectsList: []
  };

  public selectedClass: StudentClass = {
    studentClass_ID: 0,
    studentClass_Name: ''
  };

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private studentService: StudentService,
    private studentClassService: StudentClassService,
    private subjectService: SubjectService,
    private location: Location,
  ) {
    debugger;
    if (this.route.snapshot.url[0].path === 'details') {
      this.isViewMode = true;
    }
  }
  ngOnInit(): void {
    //get all classes
    this.studentClassService.getStudentClasses()
      .subscribe((classes: StudentClass[]) => {
        //get all subjects
        this.subjectService.getSubjects()
          .subscribe((subjects: StudentSubject[]) => {
            //get add/edit initial data
            const id = Number(this.route.snapshot.paramMap.get('id'));
            this.dropdownSettings = {
              idField: 'subject_ID',
              textField: 'subject_Name',
            };
            if (id) {
              this.studentService.getStudent(id)
                .subscribe(st => {
                  debugger;
                  this.student = {
                    student_ID: st.student_ID,
                    studentClass_ID: st.studentClass_ID,
                    student_Name: st.student_Name,
                    studentClass_Name: st.studentClass_Name,
                    student_Address: st.student_Address,
                    student_BirthDate: new Date(new Date(st.student_BirthDate).toLocaleDateString("en-US")),
                    student_EmailAddress: st.student_EmailAddress,
                    classesList: classes,
                    studentClass: {
                      studentClass_ID: st.studentClass_ID,
                      studentClass_Name: st.studentClass_Name
                    },
                    studentSubjectsList: st.studentSubjectsList,
                    subjectsList: subjects
                  };
                  this.selectedClass = {
                    studentClass_ID: st.studentClass_ID,
                    studentClass_Name: st.studentClass_Name
                  };
                  debugger;
                  this.selectedItems = st.studentSubjectsList;
                  this.student.subjectsList = subjects;
                }
                );
            } else {
              this.student.classesList = classes;
              this.student.subjectsList = subjects;
            }
          });
      });
  }
  onItemSelect(item: any) {
    debugger;
    let it: StudentSubject = {
      id: 0,
      student_ID: this.student.student_ID,
      student_Name: this.student.student_Name,
      subject_ID: item.subject_ID,
      subject_Name: item.subject_Name
    };
    this.student.studentSubjectsList.push(it);
  }
  onItemDeSelect(item: any) {
    debugger;
    let it: StudentSubject = {
      id: 0,
      student_ID: this.student.student_ID,
      student_Name: this.student.student_Name,
      subject_ID: item.subject_ID,
      subject_Name: item.subject_Name
    };
    this.student.studentSubjectsList = this.student.studentSubjectsList
      .filter(obj => {
        return obj.subject_ID !== it.subject_ID;
      });
  }

  goBack(): void {
    this.location.back();
  }

  save(): void {
    this.checkValidation();
    
    if (!(this.student_Name_Error || this.student_Address_Error || this.student_EmailAddress_Error || this.student_BirthDate_Error || this.student_Class_Error || this.student_Subject_Error)) {
      if (this.student.student_ID > 0) {
        this.studentService.updateStudent(this.student)
          .subscribe(() => this.goBack());
      } else {
        this.studentService.addStudent(this.student)
          .subscribe(() => this.goBack());
      }
    }
  }
  checkValidation():void{
    if (this.student.student_Name == "") {
      this.student_Name_Error = true;
      document.getElementById('student_Name')?.classList.add('is-invalid');
    } else {
      this.student_Name_Error = false;
      document.getElementById('student_Name')?.classList.remove('is-invalid');
      document.getElementById(`student_Name_error`)?.hidden;
    }
    if (this.student.student_Address == "") {
      this.student_Address_Error = true;
      document.getElementById('student_address')?.classList.add('is-invalid');
    } else {
      this.student_Address_Error = false;
      document.getElementById('student_address')?.classList.remove('is-invalid');
      document.getElementById('student_Address_error')?.hidden;
    }
    this.checkEmailValidation();
    if (this.student.student_BirthDate.toDateString() == "") {
      this.student_BirthDate_Error = true;
      document.getElementById('student_BirthDate')?.classList.add('is-invalid');
    } else {
      this.student_BirthDate_Error = false;
      document.getElementById('student_BirthDate')?.classList.remove('is-invalid');
      document.getElementById('student_BirthDate_error')?.hidden;
    }
    if (this.student.studentClass_ID == 0) {
      this.student_Class_Error = true;
      document.getElementById('student_Class')?.classList.add('is-invalid');
    } else {
      this.student_Class_Error = false;
      document.getElementById('student_Class')?.classList.remove('is-invalid');
      document.getElementById('student_Class_error')?.hidden;
    }
    if (this.student.studentSubjectsList.length == 0) {
      this.student_Subject_Error = true;
      document.getElementById('student_subjectsList')?.classList.add('is-invalid');
    } else {
      this.student_Subject_Error = false;
      document.getElementById('student_subjectsList')?.classList.remove('is-invalid');
      document.getElementById('student_subjectsList_error')?.hidden;
    }

  }
  checkEmailValidation():void{
    let student_EmailAddress_error=document.getElementById('student_EmailAddress_error');
    let student_EmailAddress_regex=document.getElementById('student_EmailAddress_regex');
    if (this.student.student_EmailAddress == "") {
      this.student_EmailAddress_Error = true;
      document.getElementById('student_EmailAddress')?.classList.add('is-invalid');
      if(student_EmailAddress_error!=null)student_EmailAddress_error.hidden=false;
      if(student_EmailAddress_regex!=null)student_EmailAddress_regex.hidden=true;
    } else {
      const regex = new RegExp('^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$');
      const valid = regex.test(this.student.student_EmailAddress);
      if (valid) {
        this.student_EmailAddress_Error = false;
        document.getElementById('student_EmailAddress')?.classList.remove('is-invalid');
        if(student_EmailAddress_regex!=null)student_EmailAddress_regex.hidden=true;
        if(student_EmailAddress_error!=null)student_EmailAddress_error.hidden=true;
      } else {
        this.student_EmailAddress_Error = true;
        if(student_EmailAddress_error!=null)student_EmailAddress_error.hidden=true;
        if(student_EmailAddress_regex!=null)student_EmailAddress_regex.hidden=false;
        document.getElementById('student_EmailAddress')?.classList.add('is-invalid');
      }
    }
  }
}
