namespace DotNetCenter.Beyond.Web.Identity.Infrastructure.SqlServer.Common.Model.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using DotNetCenter.Beyond.Web.Identity.Core.Common.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    public abstract  class AppRoleConfig<TEntity, TKeyRole> 
        : IEntityTypeConfiguration<TEntity> where TEntity 
        : AppRole<TKeyRole> where TKeyRole : IEquatable<TKeyRole>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(o => o.Id);

            if (typeof(TKeyRole) == typeof(Guid))
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
