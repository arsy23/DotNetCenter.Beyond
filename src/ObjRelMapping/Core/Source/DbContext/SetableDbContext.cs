namespace DotNetCenter.Beyond.ObjRelMapping.Core.DbContext
{
    using Microsoft.EntityFrameworkCore;
    public interface SetableDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}