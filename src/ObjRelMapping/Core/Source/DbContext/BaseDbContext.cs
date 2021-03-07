namespace DotNetCenter.Beyond.ObjRelMapping.Core.DbContext
{
    using DotNetCenter.Beyond.ObjRelMapping.Core.DbContext;
    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using System.Threading.Tasks;
    public abstract class BaseDbContext<TContext> : DbContext, DbService<TContext> 
	where TContext 
	: DbContext
    {
        private readonly string _defaultSchema;

        public BaseDbContext(DbContextOptions<TContext> options, string defaultSchema = "dbo") 
	  : base(options)
          =>  _defaultSchema = defaultSchema;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            if (!string.IsNullOrEmpty(_defaultSchema) && !string.IsNullOrWhiteSpace(_defaultSchema))
                builder.HasDefaultSchema(_defaultSchema);

            base.OnModelCreating(builder);
        }

        public abstract void Save();

        public abstract Task<int> SaveAsync(CancellationToken cancellationToken = default);
    }
}
