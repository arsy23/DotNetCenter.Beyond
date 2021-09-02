namespace DotNetCenter.Beyond.Web.Identity.Infrastructure.SqlServer.Common.Model
{ 
    using Microsoft.EntityFrameworkCore;
    using DotNetCenter.Beyond.Web.Identity.ObjRelMapping.Common.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    public abstract  class AppRoleConfig<TEntity> 
        : IEntityTypeConfiguration<TEntity> 
        where TEntity : AppRole
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(o => o.Id);

                builder
                    .Property(c => c.Id)
                    .HasDefaultValueSql("NEWID()");
        }
    }
}
