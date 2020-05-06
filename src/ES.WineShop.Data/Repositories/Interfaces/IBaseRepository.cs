using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ES.WineShop.Data.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> : IDisposable
        where TEntity : class
    {
        Task<TEntity> SelectAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IList<TEntity>> SelectAllAsync();

        bool Any(Expression<Func<TEntity, bool>> predicate);

        TEntity Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task DeleteAsync(params object[] keyValues);
        Task SaveChangesAsync();
    }
}
