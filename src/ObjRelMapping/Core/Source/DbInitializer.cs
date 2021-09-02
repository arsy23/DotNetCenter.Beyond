namespace DotNetCenter.Beyond.ObjRelMapping.Core
{
    using DotNetCenter.Beyond.ObjRelMapping.Core.DbContext;
    public interface DbInitializer
    {
        public void Initialize(DbService context);
        public void SeedEverything(DbService context);
    }
}