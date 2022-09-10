using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Model.Models
{
    public class StudentSubject
    {
        public int ID { get; set; }
        public int Student_ID { get; set; }
        public int Subject_ID { get; set; }
        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
