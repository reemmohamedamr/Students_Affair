using System;
using System.Collections.Generic;
using System.Text;

namespace Students.DAL.IRepositories
{
    public interface IGenericRepository<T,TKey>:IBaseRepository<T,TKey> where T: class
    {
        void Add(T entity);
        void Attach(T entity);
        void Delete(T entity);
        void SaveChanges();
    }
}
