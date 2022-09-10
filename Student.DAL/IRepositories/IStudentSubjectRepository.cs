using Students.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Students.DAL.IRepositories
{
    public interface IStudentSubjectRepository
    {
        IQueryable<StudentSubject> GetStudentSubjects();
    }
}
