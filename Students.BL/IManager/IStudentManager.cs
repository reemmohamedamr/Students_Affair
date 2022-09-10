using Students.Model.CustomModels;
using Students.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Students.BL.IManager
{
    public interface IStudentManager
    {
        IQueryable<StudentModel> GetStudents();
        StudentModel GetStudentByID(int id);
        void AddStudent(StudentModel studentModel);
        StudentModel UpdateStudent(StudentModel studentModel);
        void DeleteStudent(int id);
    }
}
