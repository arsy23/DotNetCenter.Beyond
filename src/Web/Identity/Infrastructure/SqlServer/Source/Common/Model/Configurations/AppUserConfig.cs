namespace DotNetCenter.Beyond.Web.Identity.Infrastructure.SqlServer.Common.Model.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using DotNetCenter.Beyond.Web.Identity.Core.Common.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    public abstract  class AppUserConfig<TEntity, TKeyUser> 
        : IEntityTypeConfiguration<TEntity> where TEntity 
        : AppUser<TKeyUser> where TKeyUser :  IEquatable<TKeyUser>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {


            if (typeof(TKeyUser) == typeof(Guid))
            {
                builder.Property(c => c.Id)
                    .HasDefaultValueSql("NEWID()")
                    .IsRequired();
            }
            else
            {
                builder
                .Property(o => o.Id)
                .UseIdentityColumn(1, 1);
            }

            builder
                .Property(p => p.DisplayName)
                .HasComputedColumnSql("[LastName] + ', ' + [FirstName]");

            builder
                .Property(o => o.DateRegistered)
                .IsRequired();
        }
    }
}
