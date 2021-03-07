namespace DotNetCenter.Beyond.Web.Identity.Infrastructure.SqlServer.Common.Model.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using DotNetCenter.Beyond.Web.Identity.Core.Common.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    public abstract  class ApplicationUserTokenConfig<TEntity, TKeyUser> 
        : IEntityTypeConfiguration<TEntity> where TEntity
        : AppUserToken<TKeyUser> where TKeyUser : IEquatable<TKeyUser>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
        }
    }
}
