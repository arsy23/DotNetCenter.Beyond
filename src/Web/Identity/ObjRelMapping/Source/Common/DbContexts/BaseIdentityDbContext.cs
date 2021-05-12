namespace DotNetCenter.Beyond.Web.Identity.ObjRelMapping.Common.DbContexts
{
    using DotNetCenter.Beyond.Web.Identity.Core;
    using DotNetCenter.Beyond.ObjRelMapping.Core.Auditing;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using DotNetCenter.Beyond.Web.Identity.Core.Models;

    public abstract  class BaseIdentityDbContext<TContext>
        : IdentityDbContext<AppUser, AppRole, Guid, AppUserClaim, AppUserRole, AppUserLogin, AppRoleClaim, AppUserToken>
        where TContext : IdentityDbContext<AppUser, AppRole, Guid, AppUserClaim, AppUserRole, AppUserLogin, AppRoleClaim, AppUserToken>
        , new()
    {
        public BaseIdentityDbContext()  { }
        public BaseIdentityDbContext(DbContextOptions<TContext> options, Auditable auditor)
            : base(options) => _auditor = auditor;

        private readonly Auditable _auditor;
        public void Audit() => _auditor.UpdateModifiedAll(ChangeTracker);

        public abstract void Save();
        public abstract Task<int> SaveAsync(CancellationToken cancellationToken);
    }
}
