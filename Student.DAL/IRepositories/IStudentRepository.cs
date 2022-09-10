using System;
using System.Collections.Generic;
using System.Linq;
using Students.Model.Models;

namespace Students.DAL.IRepositories
{
    public interface IStudentRepository
    {
        IQueryable<Student> GetStudents();
        Student GetStudentByID(int id);
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(Student student);
    }
}
