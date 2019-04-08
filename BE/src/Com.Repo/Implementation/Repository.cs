using Microsoft.EntityFrameworkCore;
using System;

namespace Com.Repo
{
    public class Repository<TContext> : ReadOnlyRepository<TContext>, IRepository
    where TContext : DbContext
    {
        public Repository(TContext context)
        : base(context)
        {
        }

        public void Create<TEntity>(TEntity entity) where TEntity : class
        {
            context.Set<TEntity>().Add(entity);
        }

        public void Delete<TEntity>(Guid id) where TEntity : class
        {
            TEntity entity = context.Set<TEntity>().Find(id);
            Delete(entity);
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            var dbSet = context.Set<TEntity>();
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update<TEntity>(TEntity entity, string modifiedBy = null) where TEntity : class
        {
            context.Set<TEntity>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
