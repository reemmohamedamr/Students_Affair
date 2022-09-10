using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Model.CustomModels
{
    public class StudentSubjectModel
    {
        public int ID { get; set; }
        public int Student_ID { get; set; }
        public string Student_Name { get; set; }
        public int Subject_ID { get; set; }
        public string Subject_Name { get; set; }
    }
}
