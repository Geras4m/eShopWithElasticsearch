using ES.WineShop.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ES.WineShop.Data.Repositories
{
    internal abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        #region Private Fields, Constructors
        protected readonly DbContext _context;
        private readonly DbSet<TEntity> _entities;

        protected BaseRepository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _entities = context.Set<TEntity>();
        }
        #endregion

        #region READ/Select methods

        /// <summary>
        /// Returns an entity from DbSet filtered based on predicate.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<TEntity> SelectAsync(Expression<Func<TEntity, bool>> predicate) =>
            await _entities.FindAsync(predicate);

        /// <summary>
        /// Returns all entities in DbSet
        /// </summary>
        /// <returns></returns>
        public async Task<IList<TEntity>> SelectAllAsync() =>
                await _entities.ToListAsync();

        #endregion

        public bool Any(Expression<Func<TEntity, bool>> predicate) =>
            _entities.Any(predicate);

        #region C-UD Methods

        /// <summary>
        /// Adds new entity to DbSet.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public TEntity Insert(TEntity entity) =>
            _entities.AddAsync(entity).Result.Entity;

        /// <summary>
        /// Modifies some or all property values of entity.
        /// </summary>
        /// <param name="entity"></param>
        public void Update(TEntity entity) =>
            _context.Entry(entity).State = EntityState.Modified;

        /// <summary>
        /// Removes an entity from DbSet. 
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public async Task DeleteAsync(params object[] keyValues) =>
            _entities.Remove(await _entities.FindAsync(keyValues));

        public void Delete(TEntity entity) =>
            _entities.Remove(entity);

        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();

        #endregion

        #region Disposabel NVI
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_entities != null)
                    _context.Dispose();
            }
        }
        #endregion
    }
}
