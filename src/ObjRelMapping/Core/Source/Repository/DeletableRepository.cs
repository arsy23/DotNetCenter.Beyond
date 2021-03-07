namespace DotNetCenter.Beyond.ObjRelMapping.Core.Repository
{
    using DotNetCenter.Core;
    using System.Threading.Tasks;
    public interface DeletableRepository<TEntity, TKey> where TEntity : Entity<TKey> where TKey : struct
    {
        void Delete(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}