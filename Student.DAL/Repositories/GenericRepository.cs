using Microsoft.EntityFrameworkCore;
using Students.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Students.DAL.Repositories
{
    public abstract class GenericRepository<T,TKey>:IGenericRepository<T,TKey>
        where T:class
    {
        protected readonly IUnitOfWork _unitOfWork;
        readonly protected DbSet<T> _objectSet;

        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _objectSet = unitOfWork.Context.SetDbSet<T>();
        }
        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null, Expression<Func<T, object>>[] includeExpressions = null)
        {
            IQueryable<T> set = this._unitOfWork.Context.Get<T>();
            PrepareDatasetFunctions(ref set, predicate, includeExpressions);
            return set.AsQueryable();
        }
        public virtual T Get(Expression<Func<T, bool>> predicate = null, Expression<Func<T, object>>[] includeExpressions = null)
        {
            IQueryable<T> set = this._unitOfWork.Context.Get<T>();
            PrepareDatasetFunctions(ref set, predicate, includeExpressions);
            return set.FirstOrDefault(predicate);
        }
        public virtual IQueryable<T> Get()
        {
            return this._unitOfWork.Context.Get<T>().AsQueryable();
        }
        public void PrepareDatasetFunctions(ref IQueryable<T> dataset, Expression<Func<T, bool>> predicate = null, Expression<Func<T, object>>[] includeExpressions = null)
        {
            if(predicate!=null)
            {
                dataset = dataset.Where(predicate);
            }
            if (includeExpressions!=null && includeExpressions.Length>0)
            {
                foreach(var includeExpression in includeExpressions)
                {
                    dataset = dataset.Include(includeExpression);
                }
            }
        }
        public void Add(T entity)
        {
            _objectSet.Add(entity);
            this._unitOfWork.SaveChanges();
        }
        public void Update(T entity)
        {
            _objectSet.Attach(entity).State=EntityState.Modified;
            this._unitOfWork.SaveChanges();
        }
        public void Attach(T entity)
        {
            _objectSet.Attach(entity);
        }
        public void Delete(T entity)
        {
            _objectSet.Remove(entity);
            this._unitOfWork.SaveChanges();
        }
        public void SaveChanges()
        {
            this._unitOfWork.SaveChanges();
        }
    }
}
