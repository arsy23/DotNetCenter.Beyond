//namespace DotNetCenter.Beyond.Web.Identity.ObjRelMapping.Common.Configurations
//{
//    using Microsoft.EntityFrameworkCore;
//    using DotNetCenter.Beyond.Web.Identity.ObjRelMapping.Common.Models;
//    using Microsoft.EntityFrameworkCore.Metadata.Builders;
//    using System;
//    using DotNetCenter.Beyond.Web.Identity.ObjRelMapping.Common.Models;
//    using DotNetCenter.Beyond.ObjRelMapping.Infrastructure.Configuration;
//    using DotNetCenter.Core;

//    public abstract  class AppRoleClaimConfig<TEntity>
//         : BaseEntityConfiguration<TEntity, int>
//        where TEntity : class, IRoleClaim, Entity<int>, new()
//    {
//        public AppRoleClaimConfig(bool configureKey = true)
//            :base(configureKey)
//        {

//        }
//        public AppRoleClaimConfig(string tableName, string schemaName, bool includeAuditColumns = true)
//            : base(tableName, schemaName, includeAuditColumns)
//        {

//        }
//        public AppRoleClaimConfig(bool configureKey = true)
//            : base(configureKey)
//        {
//        }
//        public override void Configure(EntityTypeBuilder<TEntity> builder)
//        {
//            base.Configure(builder);
//        }
//    }
//}
