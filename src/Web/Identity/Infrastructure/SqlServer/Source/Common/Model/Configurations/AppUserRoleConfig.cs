namespace DotNetCenter.Beyond.Web.Identity.Infrastructure.SqlServer.Common.Model.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using DotNetCenter.Beyond.Web.Identity.Core.Common.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    public abstract  class AppUserRoleConfig<TEntity, TKeyUserAndRole> 
        : IEntityTypeConfiguration<TEntity> where TEntity 
        : AppUserRole<TKeyUserAndRole> where TKeyUserAndRole : IEquatable<TKeyUserAndRole>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(o => o.Id);

            if (typeof(TKeyUserAndRole) == typeof(Guid))
            {
                builder
                    .Property(c => c.Id)
                    .HasDefaultValueSql("NEWID()");
            }
            else
            {
                builder
                .Property(o => o.Id)
                .UseIdentityColumn(1, 1);
            }
        }
    }
}
