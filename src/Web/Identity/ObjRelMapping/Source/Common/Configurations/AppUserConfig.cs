namespace DotNetCenter.Beyond.Web.Identity.ObjRelMapping.Common.Models
{
    using Microsoft.EntityFrameworkCore;
    using DotNetCenter.Beyond.Web.Identity.ObjRelMapping.Common.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    public abstract  class AppUserConfig<TEntity> 
        : IEntityTypeConfiguration<TEntity> 
        where TEntity : AppUser
    {
        /// <summary>
        /// Schema must configred in ef apps that use multi context with different schamas,
        /// also all configurtins of schemas must configured on all context that used eachother entity
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="schemaName"></param>
        /// <param name="includeAuditColumns"></param>
        public AppUserConfig(string tableName, string schemaName, bool includeAuditColumns = true)
        {
            _tableName = tableName;
            _schemaName = schemaName;
            _includeAuditColumns = includeAuditColumns;
        }
        public virtual string TableName => _tableName;
        private readonly string _tableName;
        public virtual string SchemaName => _schemaName;
        private readonly string _schemaName;
        public virtual bool IncludeAuditColumns => _includeAuditColumns;
        private readonly bool _includeAuditColumns;
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            if (string.IsNullOrEmpty(SchemaName))
                builder.ToTable(TableName);
            else
                builder.ToTable(TableName, SchemaName);


            builder
                .Property(o => o.Id)
                .UseIdentityColumn(seed: 1, increment: 1)
                .ValueGeneratedOnAdd()
                .IsRequired();


            builder
                .Property(p => p.DisplayName)
                .HasComputedColumnSql("[LastName] + ', ' + [FirstName]");
        }
    }
}
