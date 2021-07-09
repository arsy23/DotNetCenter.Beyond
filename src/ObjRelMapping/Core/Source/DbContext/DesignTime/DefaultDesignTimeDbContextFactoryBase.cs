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
            if (args.Length == 1)
            {
                basePath = args[0] + $"{separator}";
                Console.WriteLine($"base path : {basePath}");
            }
            if (args.Length == 2)
            {
                basePath = args[1] + $"{separator}";
                Console.WriteLine($"base path : {basePath}");
            }

            return Create(configuration);
        }
    }
}
