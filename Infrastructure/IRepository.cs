using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WsCRM.Infrastructure
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity model, bool persist = false);

        TEntity GetById(int id);
        TEntity GetByName(string name);

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetAll();

        void Update(TEntity model, bool persist = false);

        void Remove(int id, bool persist = false);
        void Remove(TEntity model, bool persist = false);

        void Save();
    }
}
