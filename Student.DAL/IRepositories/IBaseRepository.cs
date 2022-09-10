using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Students.DAL.IRepositories
{
    public interface IBaseRepository<T,TKey> where T: class
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null, Expression<Func<T, object>>[] includeExpressions = null);
        IQueryable<T> Get();
        T Get(Expression<Func<T, bool>> predicate = null, Expression<Func<T, object>>[] includeExpressions = null);
    }
}
