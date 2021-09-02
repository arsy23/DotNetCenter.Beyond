//namespace DotNetCenter.Beyond.Web.Identity.ObjRelMapping.DbContextServices
//{
//    using DotNetCenter.Beyond.Web.Identity.Core;
//    using DotNetCenter.Beyond.ObjRelMapping.Core.Auditing;
//    using Microsoft.AspNetCore.Identity;
//    using Microsoft.EntityFrameworkCore;
//    using System;
//    using System.Threading;
//    using System.Threading.Tasks;
//    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//    using DotNetCenter.Beyond.Web.Identity.ObjRelMapping.Common.Models;

//    public abstract  class BaseIdentityDbContext
//        <TContext, TAppUser, TAppRole, TAppUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
//        : IdentityDbContext<TAppUser, TAppRole, Guid, TAppUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
//        where TContext : IdentityDbContext<TAppUser, TAppRole, Guid, TAppUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
//        where TAppUser : AppUser
//        where TAppRole : AppRole
//        where TAppUserClaim : AppUserClaim
//        where TUserRole : AppUserRole
//        where TUserLogin : AppUserLogin
//        where TRoleClaim : AppRoleClaim
//        where TUserToken : AppUserToken
//        , new()
//    {
//        public BaseIdentityDbContext()  { }
//        public BaseIdentityDbContext(DbContextOptions<TContext> options, Auditable auditor)
//            : base(options) => _auditor = auditor;

//        private readonly Auditable _auditor;
//        public void Audit() => _auditor.UpdateModifiedAll(ChangeTracker);

//        public abstract void Save();
//        public abstract Task<int> SaveAsync(CancellationToken cancellationToken);
//    }
//}

using DotNetCenter.Beyond.Web.Identity.Core;
using DotNetCenter.Beyond.ObjRelMapping.Core.Auditing;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DotNetCenter.Beyond.Web.Identity.ObjRelMapping.Common.Models;
using System.Reflection;

namespace DotNetCenter.Beyond.Web.Identity.ObjRelMapping.DbContextServices
{ 
    public abstract class BaseIndetityDbContext<TIdentityDbContext, TAppUser, TAppRole>
        : IdentityDbContext<TAppUser, TAppRole, int>
        , IdentityDbService
        where TAppUser : IdentityUser<int>, IIdentityUser, new()
        where TAppRole : IdentityRole<int>, IAppRole, new()
        where TIdentityDbContext : BaseIndetityDbContext<TIdentityDbContext, TAppUser, TAppRole>
    {

    public BaseIndetityDbContext() { }
    public BaseIndetityDbContext(DbContextOptions<TIdentityDbContext> options, Auditable auditor)
        : base(options) => _auditor = auditor;

        public virtual string Schema { get; }
        public abstract Assembly ConfigurationAssemby { get; }
        public abstract bool UseAssemblyToScanConfigurations { get; }
        public abstract bool EnableSensitiveDataLogging { get; }

        private readonly Auditable _auditor;
    public virtual void Audit() => _auditor.UpdateModifiedAll(ChangeTracker);
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.EnableSensitiveDataLogging(UseAssemblyToScanConfigurations);
    }
        public void Save()
        => SaveChanges();


    public async Task<int> SaveAsync(CancellationToken cancellationToken)
        => await SaveChangesAsync(cancellationToken);
        public async Task<int> SaveAsync()
    => await SaveChangesAsync(new CancellationToken(false));
        protected override void OnModelCreating(ModelBuilder builder)
    {
            base.OnModelCreating(builder);

            if (!string.IsNullOrEmpty(Schema) && !string.IsNullOrWhiteSpace(Schema))
                builder.HasDefaultSchema(Schema);
            else
                builder.HasDefaultSchema("IDS");


            if (UseAssemblyToScanConfigurations)
                builder.ApplyConfigurationsFromAssembly(ConfigurationAssemby);
    }
}
}
