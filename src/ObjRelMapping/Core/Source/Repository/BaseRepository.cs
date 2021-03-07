namespace DotNetCenter.Beyond.ObjRelMapping.Core.Repository
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DotNetCenter.Beyond.ObjRelMapping.Core.DbContext;
    using DotNetCenter.Core;
    using System;

    public class BaseRepository<TContext, TEntity, TKey> : RepositoryService<TContext, TEntity, TKey>
    where TKey : struct
    where TEntity : class, Entity<TKey>
    where TContext : DbService<TContext>
    {
        protected readonly DbService<TContext> _dbService;
        public BaseRepository(DbService<TContext> dbService)
            => _dbService = dbService;
        public async Task<TEntity> GetByIdAsync(TKey id)
            => await _dbService.Set<TEntity>().FindAsync(id);
        public TEntity GetById(TKey id)
            => _dbService.Set<TEntity>().Find(id);
        public List<TEntity> List()
            => _dbService.Set<TEntity>().ToList();
        public async Task<List<TEntity>> ListAsync()
            => await _dbService.Set<TEntity>().ToListAsync();

        public TEntity Add(TEntity entity)
        {
            _dbService.Set<TEntity>().Add(entity);
            _dbService.Save();
            return entity;
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            _dbService.Set<TEntity>().Add(entity);
            await _dbService.SaveAsync();
            return entity;
        }

        public void Delete(TEntity entity)
        {
            _dbService.Set<TEntity>().Attach(entity);
            var dbContext = GetDbContext(entity);
            dbContext.Entry(entity).State = EntityState.Deleted;
            //_dbService.Set<T>().Remove(entity);
            _dbService.Save();
        }
        public async Task DeleteAsync(TEntity entity)
        {
            _dbService.Set<TEntity>().Attach(entity);
            var dbContext = GetDbContext(entity);
            dbContext
            .Entry(entity).State = EntityState.Deleted;
            //_dbService.Set<T>().Remove(entity);
            await _dbService.SaveAsync();
        }

        private DbContext GetDbContext(TEntity entity)
        {
            var dbContext = GetDbContext(entity);
            dbContext
            .Entry(entity).State = EntityState.Deleted;

            return dbContext;
        }

        public void Update(TEntity entity)
        {
            var dbContext = GetDbContext(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
            _dbService.Save();
        }
        public async Task UpdateAsync(TEntity entity)
        {
            var dbContext = GetDbContext(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
            await _dbService.SaveAsync();
        }
        public void Dispose()
            => _dbService.Dispose();
    }
}
