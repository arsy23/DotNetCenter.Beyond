namespace DotNetCenter.Beyond.Web.Identity.Infrastructure.SqlServer.Common.Model.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using DotNetCenter.Beyond.Web.Identity.Core.Common.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    public abstract  class AppUserClaimConfig<TEntity, TKeyUser> 
        : IEntityTypeConfiguration<TEntity> where TEntity 
        : AppUserClaim<TKeyUser> where TKeyUser : IEquatable<TKeyUser>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(o => o.Id);

            if (typeof(TKeyUser) == typeof(Guid))
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
