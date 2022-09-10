using Students.Model.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Students.BL.IManager
{
    public interface IStudentSubjectManager
    {
        IQueryable<StudentSubjectModel> GetStudentSubjects();
    }
}
