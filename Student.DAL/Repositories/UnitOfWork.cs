using Microsoft.EntityFrameworkCore;
using Students.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students.DAL.Repositories
{
    public class UnitOfWork: IUnitOfWork,IDisposable
    {
        private MainDBContext _context = null;
        public UnitOfWork(DbContext dbContext)
        {
            if(this._context==null)
            {
                this._context = new MainDBContext(dbContext);
            }
        }
        public MainDBContext Context
        {
            get
            {
                if(this._context!=null)
                {
                    return this._context;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }
        public void SaveChanges()
        {
            this._context.SaveChanges();
        }
        public void ExecuteNonQuery(string sqlStatement)
        {
            var command = Context._dbContext.Database.GetDbConnection().CreateCommand();
            command.CommandText = sqlStatement;
            Context._dbContext.Database.OpenConnection();
            var result = command.ExecuteNonQuery();
            Context._dbContext.Database.CloseConnection();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            { 
                if(disposing)
                {
                    this._context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
