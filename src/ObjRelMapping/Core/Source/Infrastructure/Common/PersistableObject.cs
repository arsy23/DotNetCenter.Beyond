using DotNetCenter.Core.Entities;
using System;

namespace DotNetCenter.Beyond.ObjRelMapping.Core.Infrastructure.Common
{
    public interface PersistableObject<TKey, TKeyUser, TKeyAuditor> : InfrastructureDao<TKey>, IDataAccessObject<TKey>, AuditableEntity<TKey, TKeyAuditor>
        where TKey : struct, IEquatable<TKey>
        where TKeyAuditor : struct, IEquatable<TKeyAuditor>
    {
    }
}