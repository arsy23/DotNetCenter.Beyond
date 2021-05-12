namespace DotNetCenter.Beyond.Web.Identity.Infrastructure.SqlServer.Common.Model.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using DotNetCenter.Beyond.Web.Identity.Core.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    public abstract  class AppUserConfig<TEntity> 
        : IEntityTypeConfiguration<TEntity> 
        where TEntity : AppUser
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {


                builder.Property(c => c.Id)
                    .HasDefaultValueSql("NEWID()")
                    .IsRequired();

            builder
                .Property(p => p.DisplayName)
                .HasComputedColumnSql("[LastName] + ', ' + [FirstName]");

            builder
                .Property(o => o.DateRegistered)
                .IsRequired();
        }
    }
}
