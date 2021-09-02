//namespace DotNetCenter.Beyond.Web.Identity.ObjRelMapping.Common.Models
//{
//    using Microsoft.EntityFrameworkCore;
//    using DotNetCenter.Beyond.Web.Identity.ObjRelMapping.Common.Models;
//    using Microsoft.EntityFrameworkCore.Metadata.Builders;
//    using System;
//    using DotNetCenter.Beyond.ObjRelMapping.Infrastructure.Configuration;

//    public abstract class AppUserRoleConfig<TEntity>
//        : BaseEntityConfiguration<TEntity, int>
//        where TEntity : class, IRoleClaim, new()
//    {
//        public AppUserRoleConfig(string tableName, string schemaName, bool includeAuditColumns = true)
//            : base(tableName, schemaName, includeAuditColumns)
//        {

//        }
//        public AppUserRoleConfig(bool includeAuditColumns = true)
//            : base(includeAuditColumns)
//        {
//        }
//        public override void Configure(EntityTypeBuilder<TEntity> builder)
//        {
//            base.Configure(builder);
//        }
//    }
//}
