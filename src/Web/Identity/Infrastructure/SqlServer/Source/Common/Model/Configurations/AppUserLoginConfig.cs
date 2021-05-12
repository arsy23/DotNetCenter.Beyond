namespace DotNetCenter.Beyond.Web.Identity.Infrastructure.SqlServer.Common.Model.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using DotNetCenter.Beyond.Web.Identity.Core.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    public abstract  class AppUserLoginConfig<TEntity> 
        : IEntityTypeConfiguration<TEntity> 
        where TEntity : AppUserLogin
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder) { }
    }
}
