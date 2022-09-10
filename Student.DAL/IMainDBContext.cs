using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Students.DAL
{
    public interface IMainDBContext
    {
        IQueryable<T> Get<T>() where T : class;
        DbSet<T> SetDbSet<T>() where T : class;
    }
}
