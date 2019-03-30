using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MasterDbStorage.DbRespository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(long id);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entity);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entity);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}