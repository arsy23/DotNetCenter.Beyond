namespace DotNetCenter.Beyond.ObjRelMapping.Core
{
    using DotNetCenter.Beyond.ObjRelMapping.Core.DbContext;
    public interface DbInitializer<TContext>
    {
        public void Initialize(DbService<TContext> context);
        public void SeedEverything(DbService<TContext> context);
    }
}