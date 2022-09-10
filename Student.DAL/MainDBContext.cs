using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Students.DAL
{
    public class MainDBContext: DbContext, IMainDBContext
    {
        public readonly DbContext _dbContext;
        public MainDBContext(DbContext dbContext)
        {
            if(this._dbContext ==null)
            {
                _dbContext = dbContext;
            }
        }
        public IQueryable<T> Get<T>() where T : class
        {
            DbSet<T> _objectSet = _dbContext.Set<T>();
            return _objectSet.AsQueryable();
        }
        public DbSet<T> SetDbSet<T>() where T : class
        {
            DbSet<T> _objectSet = _dbContext.Set<T>();
            return _objectSet;
        }
        public void SaveChanges()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
