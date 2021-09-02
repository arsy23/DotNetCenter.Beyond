using DotNetCenter.Beyond.ObjRelMapping.Core.Auditing;
using DotNetCenter.Beyond.ObjRelMapping.Core.Infrastructure.Common;
using DotNetCenter.Beyond.ObjRelMapping.Core.Infrastructure.Configuration;
using DotNetCenter.Core;
using DotNetCenter.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.ComponentModel;

namespace DotNetCenter.Beyond.ObjRelMapping.Infrastructure.Configuration
{
    public abstract class BaseEntityConfiguration<T, TKeyEntity>
    : IEntityTypeConfiguration<T>
    , AppConfiguration<T, TKeyEntity>
      where T : class, Entity<TKeyEntity>
      where TKeyEntity : struct, IEquatable<TKeyEntity>
    {
        // use constructor blow for single context ef apps
        //public BaseAppConfigurastion(string tableName)
        //{
        //    _tableName = tableName;
        //}
        /// <summary>
        /// Schema must configred in ef apps that use multi context with different schamas,
        /// also all configurtins of schemas must configured on all context that used eachother entity
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="schemaName"></param>
        /// <param name="includeAuditColumns"></param>
        public BaseEntityConfiguration(string tableName, string schemaName, bool configureKey = true)
        {
            _tableName = tableName;
            _schemaName = schemaName;
            _configureKey = configureKey;
        }
        public BaseEntityConfiguration(bool configureKey = true)
        {
            _tableName = string.Empty;
            _schemaName = string.Empty;
            _configureKey = configureKey;

        }
        public string TableName => _tableName;
        private readonly string _tableName;
        public string SchemaName => _schemaName;
        private readonly string _schemaName;
        public virtual int IdColumnSeed => 1;
        public virtual int IdColumnIncrement => 1;
        public bool ConfigureKey => _configureKey;
        private readonly bool _configureKey;
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            if (!string.IsNullOrEmpty(TableName))
            {

                if (string.IsNullOrEmpty(SchemaName))
                    builder.ToTable(TableName);
                else
                    builder.ToTable(TableName, SchemaName);

                if (_configureKey)
                {
                    builder
                        .HasKey(o => o.Id);
                    builder
                        .Property(o => o.Id)
#if NET5_0
                    .UseIdentityColumn(IdColumnSeed, IdColumnIncrement)
#elif NETCOREAPP3_1_OR_GREATER
                    .UseSqlServerIdentityColumn(IdColumnSeed, IdColumnIncrement)
#endif
                    .ValueGeneratedOnAdd();
                }
            }
        }
    }
        public abstract class BaseEntityConfiguration<T, TKeyEntity, TKeyUser, TKeyAuditor>
    : IEntityTypeConfiguration<T>
    , AppConfiguration<T, TKeyEntity>
      where T : class, PersistableObject<TKeyEntity, TKeyUser, TKeyAuditor>
      where TKeyEntity : struct, IEquatable<TKeyEntity>
      where TKeyUser : struct, IEquatable<TKeyUser>
      where TKeyAuditor : struct, IEquatable<TKeyAuditor>
    {
        // use constructor blow for single context ef apps
        //public BaseAppConfigurastion(string tableName)
        //{
        //    _tableName = tableName;
        //}
        /// <summary>
        /// Schema must configred in ef apps that use multi context with different schamas,
        /// also all configurtins of schemas must configured on all context that used eachother entity
        /// Auditable Configuration
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="schemaName"></param>
        /// <param name="includeAuditColumns"></param>
        /// <param name="configureKey"></param>
        public BaseEntityConfiguration(string tableName, string schemaName, bool includeAuditColumns = true, bool configureKey = true)
        {
            _tableName = tableName;
            _schemaName = schemaName;
            _includeAuditColumns = includeAuditColumns;
            _configureKey = configureKey;
        }
        public BaseEntityConfiguration(bool includeAuditColumns = true, bool configureKey = true)
        {
            _tableName = string.Empty;
            _schemaName = string.Empty;
            _includeAuditColumns = includeAuditColumns;
            _configureKey = configureKey;
        }
        public string TableName => _tableName;
        private readonly string _tableName;
        public string SchemaName => _schemaName;
        private readonly string _schemaName;
        public bool IncludeAuditColumns => _includeAuditColumns;
        private readonly bool _includeAuditColumns;
        public bool ConfigureKey => _configureKey;
        private readonly bool _configureKey;
        public virtual int IdColumnSeed => 1;
        public virtual int IdColumnIncrement => 1;
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            if (!string.IsNullOrEmpty(TableName))
            {

                if (string.IsNullOrEmpty(SchemaName))
                    builder.ToTable(TableName);
                else
                    builder.ToTable(TableName, SchemaName);

            }
            if (_configureKey)
            {
                builder
                    .HasKey(o => o.Id);
                builder
                    .Property(o => o.Id)
#if NET5_0
                    .UseIdentityColumn(IdColumnSeed, IdColumnIncrement)
#elif NETCOREAPP3_1_OR_GREATER
                    .UseSqlServerIdentityColumn(IdColumnSeed, IdColumnIncrement)
#endif
                    .ValueGeneratedOnAdd();
            }

            //if (typeof(int) == typeof(TEntityKey) 
            //    || typeof(short) == entityType
            //    || typeof(long) == entityType
            //    || typeof(byte) == entityType)

            var entityType = typeof(T);
            var entityName = entityType.Name;

          

            if (_includeAuditColumns)
            {
                builder
                    .Property(o => o.CreatedDateTime)
                    .IsRequired();

                builder
                    .Property(o => o.CreatedBy)
                    .IsRequired(true);


                builder
                    .Property(o => o.ModifiedDateTime)
                    .IsRequired(false);
                builder
                      .Property(o => o.ModifiedBy)
                      .IsRequired(false);

            }
            else
                IgnoreAuditColumns(builder);

        }
        protected virtual void IgnoreAuditColumns(EntityTypeBuilder<T> builder)
        {
            builder
                .Ignore(o => o.CreatedDateTime);
            builder
                .Ignore(o => o.CreatedBy);
            builder
                .Ignore(o => o.ModifiedBy);
            builder
                .Ignore(o => o.ModifiedDateTime);
        }
    }
}