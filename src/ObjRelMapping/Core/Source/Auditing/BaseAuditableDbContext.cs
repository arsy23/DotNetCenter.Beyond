namespace DotNetCenter.Beyond.ObjRelMapping.Core.DbContext
{
    using DotNetCenter.Beyond.ObjRelMapping.Core.Auditing;
    using DotNetCenter.Beyond.ObjRelMapping.Core.DbContext;
    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using System.Threading.Tasks;
    public abstract class BaseAuditableDbContext<TContext> 
	: DbContext
	, AuditableDbService<TContext> 
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

            //builder.ApplyConfigurationsFromAssembly(typeof(DatabaseService<>).Assembly);

            base.OnModelCreating(builder);
        }
        public void Audit()
            => _auditor.UpdateModifiedAll(ChangeTracker);
        public abstract void Save();

        public abstract Task<int> SaveAsync(CancellationToken cancellationToken = default);
    }
}
