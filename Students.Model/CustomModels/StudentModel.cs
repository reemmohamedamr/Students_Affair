using Students.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Students.Model.CustomModels
{
    public class StudentModel
    {
        public int Student_ID { get; set; }
        public int StudentClass_ID { get; set; }
        public string StudentClass_Name { get; set; }
        public string Student_Name { get; set; }
        public string Student_Address { get; set; }
        public DateTime Student_BirthDate { get; set; }
        public string Student_EmailAddress { get; set; }
        public List<StudentClassModel> ClassesList { get; set; }
        public List<StudentSubjectModel> StudentSubjectsList { get; set; }
    }
}
