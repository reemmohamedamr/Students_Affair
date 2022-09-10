using Students.DAL.IRepositories;
using Students.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Students.DAL.Repositories
{
    public class StudentClassRepository : GenericRepository<StudentClass, int>, IStudentClassRepository
    {
        public StudentClassRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }
        public IQueryable<StudentClass> GetStudentClasses()
        {
            return GetAll();
        }
        public StudentClass GetStudentClassByID(int id)
        {
            return GetAll(x => x.StudentClass_ID == id).FirstOrDefault();
        }
    }
}
