using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Data.EFCore
{
    public abstract class EfCoreRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        protected readonly TContext context;

        public EfCoreRepository(TContext context) => this.context = context;

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return entity;
        }

        public async Task<TEntity> DeleteAsync(long id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id).ConfigureAwait(false);
            if (entity == null)
            {
                return entity;
            }

            //context.Set<TEntity>().Remove(entity);
            entity.IsDeleted = true;
            await context.SaveChangesAsync().ConfigureAwait(false);

            return entity;
        }

        public async Task<TEntity> GetAsync(long id)
            //=> await context.Set<TEntity>().FindAsync(id).ConfigureAwait(false);
            => await context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted).ConfigureAwait(false);

        public async Task<List<TEntity>> GetAllAsync()
            => await context.Set<TEntity>().Where(x => !x.IsDeleted).ToListAsync().ConfigureAwait(false);

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync().ConfigureAwait(false);
            return entity;
        }
    }
}
