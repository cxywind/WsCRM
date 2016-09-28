using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace WsCRM.Infrastructure.Data
{
     public interface IUnitOfWork
    {
        DbContext GetDbContext();
        DbEntityEntry<T> Entry<T>(T entity) where T : class;
        IDbSet<T> Set<T>() where T : class;
        void Commit();
        void Dispose();
    }
}
