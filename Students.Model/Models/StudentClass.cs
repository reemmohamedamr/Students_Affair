using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Model.Models
{
    public class StudentClass
    {
        public int StudentClass_ID { get; set; }
        public string StudentClass_Name { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
