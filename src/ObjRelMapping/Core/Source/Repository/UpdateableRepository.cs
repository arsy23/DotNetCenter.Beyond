namespace DotNetCenter.Beyond.ObjRelMapping.Core.Repository
{
    using DotNetCenter.Core;
    using System.Threading.Tasks;
    public interface UpdateableRepository<TEntity, TKey> where TEntity : Entity<TKey> where TKey : struct
    {
        void Update(TEntity entity);
        Task UpdateAsync(TEntity entity);
    }
}