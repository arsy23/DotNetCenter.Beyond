namespace DotNetCenter.Beyond.Web.Identity.Core.DbContextServices
{
    using DotNetCenter.Beyond.ObjRelMapping.Core.Auditing;
    using DotNetCenter.Beyond.ObjRelMapping.Core.DbContext;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    public interface IdentityDbService : IDisposable, IAsyncDisposable, AuditableDbContext, EntryableDbContext, SetableDbContext
    {
        void Save();
        Task<int> SaveAsync(CancellationToken cancellationToken = default);
    }
}