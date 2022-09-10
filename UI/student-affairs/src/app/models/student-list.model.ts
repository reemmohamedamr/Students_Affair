import { StudentClass } from "./student-class.model";
import { StudentSubject } from "./student-subject.model";

export interface StudentList {
    Student_ID: number;
    StudentClass_ID: number;
    StudentClass_Name: string;
    Student_Name: string;
    Student_Address: string;
    Student_BirthDate: Date;
    Student_EmailAddress: string;
    ClassesList:StudentClass[];
    StudentClass:StudentClass;
    StudentSubjectsList:StudentSubject[];
  }