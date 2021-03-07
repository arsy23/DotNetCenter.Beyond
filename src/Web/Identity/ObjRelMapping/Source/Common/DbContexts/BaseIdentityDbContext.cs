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
    using DotNetCenter.Beyond.Web.Identity.Core.Common.Models;

    public abstract  class BaseIdentityDbContext<TContext, TUser, TRole, TUserAndRoleKey >
        : IdentityDbContext<TUser, TRole, TUserAndRoleKey>
        where TContext : IdentityDbContext<TUser, TRole, TUserAndRoleKey>, new()
        where TUser : AppUser<TUserAndRoleKey>,  IEquatable<TUser>, new()
        where TRole : AppRole<TUserAndRoleKey>, IEquatable<TRole>, new()
        where TUserAndRoleKey : IEquatable<TUserAndRoleKey>
    {
        public BaseIdentityDbContext()
        {

        }
        public BaseIdentityDbContext(DbContextOptions<TContext> options, Auditable auditor)
            : base(options) => _auditor = auditor;
        private readonly Auditable _auditor;
        public void Audit() => _auditor.UpdateModifiedAll(ChangeTracker);
        public abstract void Save();
        public abstract Task<int> SaveAsync(CancellationToken cancellationToken);
    }
}
