namespace DotNetCenter.Beyond.Web.Identity.Infrastructure.SqlServer.Common.Model.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using DotNetCenter.Beyond.Web.Identity.Core.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    public abstract  class ApplicationUserTokenConfig<TEntity>
        : IEntityTypeConfiguration<TEntity> 
        where TEntity : AppUserToken
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
        }
    }
}
