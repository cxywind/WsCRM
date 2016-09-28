using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsCRM.Model;

namespace WsCRM.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private WsCRMEntities _dbContext;
        private bool _disposed = false;


        public UnitOfWork(WsCRMEntities dbContext)
        {
            _dbContext = dbContext;
        }

        public DbContext GetDbContext()
        {
            return _dbContext;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this._disposed = true;
        }

        //http://stackoverflow.com/questions/151051/when-should-i-use-gc-suppressfinalize
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public DbEntityEntry<T> Entry<T>(T entity) where T : class
        {
            return _dbContext.Entry<T>(entity);
        }

        public IDbSet<T> Set<T>() where T : class
        {
            return _dbContext.Set<T>();
        }
    }
}
