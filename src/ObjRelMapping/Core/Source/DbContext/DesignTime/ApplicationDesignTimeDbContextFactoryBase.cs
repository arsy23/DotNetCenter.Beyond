namespace DotNetCenter.Beyond.ObjRelMapping.Core.DbContext.DesignTime
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;

    public abstract  class ApplicationDesignTimeDbContextFactoryBase<TContext> :  IDesignTimeDbContextFactory<TContext> where TContext : DbContext
    {
        protected const string AspNetCoreEnvironment = "ASPNETCORE_ENVIRONMENT";
        private string ConnectionStringName;
        public abstract TContext CreateDbContext(string[] args);
        protected abstract TContext CreateNewInstance(DbContextOptionsBuilder<TContext> options, string connectionString);
        protected TContext Create(IConfigurationRoot configuration)
        {
            ConnectionStringName = configuration.GetSection(nameof(ConnectionStringName)).Value;
            return Create(configuration.GetConnectionString(ConnectionStringName));
        }
        private TContext Create(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException($"Connection string '{ConnectionStringName}' is null or empty.", nameof(connectionString));
            Console.WriteLine($"DesignTimeDbContextFactoryBase.Create(string): Connection string: '{connectionString}'.");
            return CreateNewInstance(new DbContextOptionsBuilder<TContext>(), connectionString);
        }
    }
}