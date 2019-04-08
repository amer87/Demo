using System;
using System.Linq;
using System.Linq.Expressions;

namespace Com.Repo
{
    public interface IRepository : IReadOnlyRepository
    {
        void Create<TEntity>(TEntity entity)
         where TEntity : class;

        void Update<TEntity>(TEntity entity, string modifiedBy = null)
            where TEntity : class;

        void Delete<TEntity>(Guid id)
            where TEntity : class;

        void Delete<TEntity>(TEntity entity)
            where TEntity : class;

        void Save();
    }
}
