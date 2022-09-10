using Microsoft.EntityFrameworkCore;
using Students.DAL.IRepositories;
using Students.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Students.DAL.Repositories
{
    public class StudentSubjectRepository : GenericRepository<StudentSubject, int>, IStudentSubjectRepository
    {
        public StudentSubjectRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }
        public IQueryable<StudentSubject> GetStudentSubjects()
        {
            return GetAll().Include(x => x.Subject).Include(x => x.Student);
        }
    }
}
