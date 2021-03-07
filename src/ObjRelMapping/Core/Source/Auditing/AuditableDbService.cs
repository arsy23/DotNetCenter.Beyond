namespace DotNetCenter.Beyond.ObjRelMapping.Core.DbContext
{
    using DotNetCenter.Beyond.ObjRelMapping.Core.Auditing;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    public interface AuditableDbService<TContext> 
	: IDisposable, IAsyncDisposable, AuditableDbContext, EntryableDbContext, SetableDbContext
    {   
        void Save();
        Task<int> SaveAsync(CancellationToken cancellationToken = default);
    }
}