using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Com.Repo
{
    public interface IReadOnlyRepository
    {
        IQueryable<TEntity> GetAll<TEntity>(
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = null,
        int? skip = null,
        int? take = null)
        where TEntity : class;

        IQueryable<TEntity> Get<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
            where TEntity : class;

        TEntity GetById<TEntity>(Guid id)
            where TEntity : class;
    }
}
