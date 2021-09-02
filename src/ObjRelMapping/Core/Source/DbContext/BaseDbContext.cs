namespace DotNetCenter.Beyond.ObjRelMapping.Core.DbContext
{
    using DotNetCenter.Beyond.ObjRelMapping.Core.DbContext;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    public abstract class BaseDbContext<TContext> : DbContext, DbService
	where TContext 
	: DbContext
    {
        public virtual string Schema => _defaultSchema;
        public readonly string _defaultSchema;
        public abstract Assembly ConfigurationAssemby { get; }
        public abstract bool UseAssemblyToScanConfigurations { get; }
        public abstract bool EnableSensitiveDataLogging { get; }
        public BaseDbContext(DbContextOptions<TContext> options, string defaultSchema = "dbo") 
	  : base(options)
          =>  _defaultSchema = defaultSchema;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging(UseAssemblyToScanConfigurations);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            if (!string.IsNullOrEmpty(_defaultSchema) && !string.IsNullOrWhiteSpace(_defaultSchema))
                builder.HasDefaultSchema(_defaultSchema);
            else
                builder.HasDefaultSchema("dbo");


            if (UseAssemblyToScanConfigurations)
                builder.ApplyConfigurationsFromAssembly(ConfigurationAssemby);
        }

        public abstract void Save();

        public abstract Task<int> SaveAsync();
        public abstract Task<int> SaveAsync(CancellationToken cancellationToken = default);
    }
}
