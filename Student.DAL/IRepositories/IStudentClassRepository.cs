using Students.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Students.DAL.IRepositories
{
    public interface IStudentClassRepository
    {
        IQueryable<StudentClass> GetStudentClasses();
        StudentClass GetStudentClassByID(int id);
    }

}
