namespace DotNetCenter.Beyond.Web.Identity.ObjRelMapping.Common.Models
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    public abstract  class AppUserClaimConfig<TEntity>
        : IEntityTypeConfiguration<TEntity> where TEntity 
        : AppUserClaim
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
