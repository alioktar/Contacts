using Contacts.Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Contacts.Core.DataAccess.EntityFreamework
{
    public class EntityRepositoryBase<TEntity> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        private readonly DbContext _context;
        private DbSet<TEntity> _entities;

        protected virtual DbSet<TEntity> Entities => _entities = _entities ?? _context.Set<TEntity>();

        public EntityRepositoryBase(DbContext context)
        {
            if (context == null)
                throw new ArgumentNullException("DB context cannot be null!!");

            _context = context;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await Entities.AddAsync(entity);
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Entities.Update(entity);
            return entity;
        }

        public TEntity Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Entities.Remove(entity);
            return entity;
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>>[] includes = null)
        {
            var query = Entities.AsNoTracking().AsQueryable();

            return includes != null ?
                await includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).SingleOrDefaultAsync(filter) :
                await query.SingleOrDefaultAsync(filter);
        }

        public async Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, object>>[] includes = null)
        {
            var query = Entities.AsNoTracking().AsQueryable();
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            }

            return filter == null
                ? await query.ToListAsync()
                : await query.Where(filter).ToListAsync();
        }
    }
}
