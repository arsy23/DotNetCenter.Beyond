namespace DotNetCenter.Beyond.ObjRelMapping.Core.DbContext
{
    using DotNetCenter.Beyond.ObjRelMapping.Core.Auditing;
    using System;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    public interface DbService: IDisposable, IAsyncDisposable, EntryableDbContext, SetableDbContext
    {   
        void Save();
        Task<int> SaveAsync();
        Task<int> SaveAsync(CancellationToken cancellationToken = default);
        public string Schema { get; }
        public Assembly ConfigurationAssemby { get; }
        public bool UseAssemblyToScanConfigurations { get; }
        public bool EnableSensitiveDataLogging { get; }
    }
}