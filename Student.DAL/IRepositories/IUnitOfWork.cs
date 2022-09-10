using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;

namespace Students.DAL.IRepositories
{
    public interface IUnitOfWork: IDisposable
    {
        MainDBContext Context { get; }
        void SaveChanges();
        void ExecuteNonQuery(string sqlStatement);
    }
}
