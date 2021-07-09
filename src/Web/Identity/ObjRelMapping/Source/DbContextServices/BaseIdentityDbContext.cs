namespace DotNetCenter.Beyond.Web.Identity.ObjRelMapping.DbContextServices
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

    public abstract  class BaseIdentityDbContext
        <TContext, TAppUser, TAppRole, TAppUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
        : IdentityDbContext<TAppUser, TAppRole, Guid, TAppUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
        where TContext : IdentityDbContext<TAppUser, TAppRole, Guid, TAppUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
        where TAppUser : AppUser
        where TAppRole : AppRole
        where TAppUserClaim : AppUserClaim
        where TUserRole : AppUserRole
        where TUserLogin : AppUserLogin
        where TRoleClaim : AppRoleClaim
        where TUserToken : AppUserToken
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
