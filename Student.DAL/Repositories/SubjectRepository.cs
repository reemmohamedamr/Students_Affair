using Microsoft.EntityFrameworkCore;
using Students.DAL.IRepositories;
using Students.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Students.DAL.Repositories
{
    public class SubjectRepository : GenericRepository<Subject, int>, ISubjectRepository
    {
        public SubjectRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }
        public IQueryable<Subject> GetSubjects()
        {
            return GetAll();
        }
    }
}