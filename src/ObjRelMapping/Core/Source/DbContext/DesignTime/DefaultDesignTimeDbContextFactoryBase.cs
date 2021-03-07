namespace DotNetCenter.Beyond.ObjRelMapping.Core.DbContext.DesignTime
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.IO;
    public abstract  class DefaultDesignTimeDbContextFactoryBase<TContext> : ApplicationDesignTimeDbContextFactoryBase<TContext> where TContext : DbContext
    {
        public override TContext CreateDbContext(string[] args)
        {
            var separator = $"{Path.DirectorySeparatorChar}";
            var basePath = $"{Directory.GetCurrentDirectory()}{separator}";
            var applicationEnvironment = Environment.GetEnvironmentVariable(AspNetCoreEnvironment);
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{applicationEnvironment}.json", true)
                .AddEnvironmentVariables()
                .Build();
            var path = args[1];
             basePath = path;
            Console.WriteLine($"base path : {basePath}");
            return Create(configuration);
        }
    }
}
