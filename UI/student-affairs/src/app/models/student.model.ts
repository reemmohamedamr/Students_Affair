import { StudentClass } from "./student-class.model";
import { StudentSubject } from "./student-subject.model";
import { Subject } from "./subject.model";

export interface Student {
    student_ID: number;
    studentClass_ID: number;
    studentClass_Name: string;
    student_Name: string;
    student_Address: string;
    student_BirthDate: Date;
    student_EmailAddress: string;
    classesList:StudentClass[];
    studentClass:StudentClass;
    studentSubjectsList:StudentSubject[];
    subjectsList:StudentSubject[];
  }