namespace DotNetCenter.Beyond.ObjRelMapping.Core.DbContext
{
    using DotNetCenter.Beyond.ObjRelMapping.Core.Auditing;
    using DotNetCenter.Beyond.ObjRelMapping.Core.DbContext;
    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using System.Threading.Tasks;
    public abstract class BaseAuditableDbContext<TContext> 
	: DbContext
	, AuditableDbService
	where TContext : DbContext
    {
        private readonly string _defaultSchema;
        private readonly Auditable _auditor;

        public BaseAuditableDbContext(DbContextOptions<TContext> options, Auditable auditor, string defaultSchema = "dbo") 
	: base(options)
        {
            _defaultSchema = defaultSchema;
            _auditor = auditor;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            if (!string.IsNullOrEmpty(_defaultSchema) && !string.IsNullOrWhiteSpace(_defaultSchema))
                builder.HasDefaultSchema(_defaultSchema);
            else
                builder.HasDefaultSchema("dbo");

            //builder.ApplyConfigurationsFromAssembly(typeof(DatabaseService<>).Assembly);

            base.OnModelCreating(builder);
        }
        public virtual void Audit() => _auditor.UpdateModifiedAll(ChangeTracker);
        public abstract void Save();
        public abstract Task<int> SaveAsync();
        public abstract Task<int> SaveAsync(CancellationToken cancellationToken = default);
    }
}
