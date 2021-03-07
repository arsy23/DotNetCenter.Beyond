namespace DotNetCenter.Beyond.Web.Identity.ObjRelMapping.Common.DbContexts
{
    using DotNetCenter.Beyond.Web.Identity.Core;
    using DotNetCenter.Beyond.Web.Identity.Core.Common.Models;
    using DotNetCenter.Beyond.ObjRelMapping.Core.Auditing;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public abstract  class BaseDetailedIdentityDbContext<TContext, TUser, TRole, TKeyUserAndRole, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken> 
        : IdentityDbContext<TUser, TRole, TKeyUserAndRole, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>, IdentityDbService
        where TUser :  AppUser<TKeyUserAndRole>, IEquatable<TUser>, new()
        where TUserRole : AppUserRole<TKeyUserAndRole>, IEquatable<TUserRole>,new()
        where TRole : AppRole<TKeyUserAndRole>, IEquatable<TRole> ,new()
        where TUserClaim : AppUserClaim<TKeyUserAndRole>, IEquatable<TUserClaim> ,new()
        where TRoleClaim : AppRoleClaim<TKeyUserAndRole>, IEquatable<TRoleClaim> ,new()
        where TUserLogin : AppUserLogin<TKeyUserAndRole>, IEquatable<TUserLogin> ,new()
        where TUserToken :  AppUserToken<TKeyUserAndRole>, IEquatable<TUserToken> ,new()
        where TContext : IdentityDbContext<TUser, TRole, TKeyUserAndRole, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>, new()
        where TKeyUserAndRole : IEquatable<TKeyUserAndRole>
    {
        public BaseDetailedIdentityDbContext()
        {
        }
        public BaseDetailedIdentityDbContext(DbContextOptions<TContext> options, Auditable auditor)
            : base(options) => _auditor = auditor;
        private readonly Auditable _auditor;
        public void Audit() => _auditor.UpdateModifiedAll(ChangeTracker);
        public abstract void Save();
        public abstract Task<int> SaveAsync(CancellationToken cancellationToken);
    }
}
