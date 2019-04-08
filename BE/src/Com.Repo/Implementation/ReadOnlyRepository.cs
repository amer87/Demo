using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Com.Repo
{
    public abstract class ReadOnlyRepository<TContext> : IReadOnlyRepository
    where TContext : DbContext
    {
        protected readonly TContext context;

        public ReadOnlyRepository(TContext context)
        {
            this.context = context;
        }

        public IQueryable<TEntity> Get<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null
        )
        where TEntity : class
        {
            includeProperties = includeProperties ?? string.Empty;
            IQueryable<TEntity> query = context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }

        public IQueryable<TEntity> GetAll<TEntity>(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, string includeProperties = null, int? skip = null, int? take = null) where TEntity : class
        {
            return Get(null, orderBy, includeProperties, skip, take);
        }

        public TEntity GetById<TEntity>(Guid id) where TEntity : class
        {
            return context.Set<TEntity>().Find(id);
        }
    }
}
