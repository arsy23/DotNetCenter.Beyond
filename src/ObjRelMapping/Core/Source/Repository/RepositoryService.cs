namespace DotNetCenter.Beyond.ObjRelMapping.Core.Repository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DotNetCenter.Beyond.ObjRelMapping.Core.DbContext;
    using Microsoft.EntityFrameworkCore.Internal;
    using DotNetCenter.Core;

    public interface RepositoryService<TContext, TEntity, TKey> 
        : UpdateableRepository<TEntity, TKey>,
        DeletableRepository<TEntity, TKey>,
        AddableRepository<TEntity, TKey>
        where TContext : DbService<TContext>
        where TEntity : Entity<TKey>
        where TKey : struct 
    {
        TEntity GetById(TKey id);
        Task<TEntity> GetByIdAsync(TKey id);
        List<TEntity> List();
        Task<List<TEntity>> ListAsync();
    }
}