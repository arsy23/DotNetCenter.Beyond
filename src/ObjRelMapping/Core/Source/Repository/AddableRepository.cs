namespace DotNetCenter.Beyond.ObjRelMapping.Core.Repository
{
    using Microsoft.EntityFrameworkCore.Internal;
    using DotNetCenter.Core;
    using System.Threading.Tasks;
    public interface AddableRepository<TEntity, TKey> where TEntity : Entity<TKey> where TKey : struct
    {
        TEntity Add(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity);
    }
}