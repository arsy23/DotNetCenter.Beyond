
namespace DotNetCenter.Beyond.ObjRelMapping.Core.DbContext
{
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.Extensions.Caching.Memory;
    public interface EntryableDbContext
    {
#if NETSTANDARD2_1
        EntityEntry Entry([NotNullAttribute] object entity);
        EntityEntry<TEntity> Entry<TEntity>([NotNullAttribute] TEntity entity) where TEntity : class;
#endif
#if NETSTANDARD2_0
        EntityEntry Entry(object entity);
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
#endif
    }
}
