using Students.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Students.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Students.DAL.Repositories
{
    public class StudentRepository:GenericRepository<Student, int>, IStudentRepository
    {
        public StudentRepository(IUnitOfWork unitOfWork)
            :base(unitOfWork)
        {

        }
        public IQueryable<Student> GetStudents()
        {
            return GetAll().Include(x=>x.StudentClass).OrderBy(x => x.Student_Name);
        }
        public Student GetStudentByID(int id)
        {
            return GetAll(x => x.Student_ID == id)
                .Include(x => x.StudentClass)
                .Include(x => x.StudentSubjects)
                .ThenInclude(x=>x.Subject).FirstOrDefault();
        }
        public void AddStudent(Student student)
        {
            Add(student);
        }
        public void UpdateStudent(Student student)
        {
            Update(student);
        }
        public void DeleteStudent(Student student)
        {
            Delete(student);
        }

    }
}
