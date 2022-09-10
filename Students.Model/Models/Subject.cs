using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Model.Models
{
    public class Subject
    {
        public Subject()
        {
            StudentSubjects = new HashSet<StudentSubject>();
        }
        public int Subject_ID { get; set; }
        public string Subject_Name { get; set; }
        public string Subject_Description { get; set; }
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }

    }
}
