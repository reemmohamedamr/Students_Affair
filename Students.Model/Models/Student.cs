using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Students.Model.Models
{
    public class Student
    {
        public Student()
        {
            StudentSubjects = new HashSet<StudentSubject>();
        }
        [Key]
        public int Student_ID { get; set; }
        public int StudentClass_ID { get; set; }
        public string Student_Name { get; set; }
        public string Student_Address { get; set; }
        public DateTime Student_BirthDate { get; set; }
        public string Student_EmailAddress { get; set; }
        public virtual StudentClass StudentClass { get; set; }
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}
