using DotNetCenter.Beyond.ObjRelMapping.Core.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DotNetCenter.Beyond.ObjRelMapping.Core.Infrastructure.Configuration
{
    internal interface AppConfiguration<T , TKeyEntity>
        where T : class
        where TKeyEntity : IEquatable<TKeyEntity>
    {
        public void Configure(EntityTypeBuilder<T> builder);

    }
}