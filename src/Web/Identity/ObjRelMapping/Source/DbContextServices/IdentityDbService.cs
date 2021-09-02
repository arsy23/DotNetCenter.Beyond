namespace DotNetCenter.Beyond.Web.Identity.ObjRelMapping.DbContextServices
{
    using DotNetCenter.Beyond.ObjRelMapping.Core.Auditing;
    using DotNetCenter.Beyond.ObjRelMapping.Core.DbContext;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    public interface IdentityDbService : DbService
    {
        void Save();
        Task<int> SaveAsync();
        Task<int> SaveAsync(CancellationToken cancellationToken = default);
    }
}