
namespace DotNetCenter.Beyond.ObjRelMapping.Core.Infrastructure.Common
{
    using DotNetCenter.Core.Entities;
    using System;
    using System.Collections.Generic;

    public interface IAppUser<TKeyUser, TKeyAuditor>: InfrastructureDao<TKeyUser>, AuditableEntity<TKeyUser, TKeyAuditor>, TrackableEntity
        where TKeyUser : struct, IEquatable<TKeyUser>
        where TKeyAuditor : struct, IEquatable<TKeyAuditor>
    {
        public string Tag { get; }
        public string UserName { get; }
        public string Email { get; }
        public string DisplayName { get; }
        //public bool ValidateIdentityUser();
    }
}