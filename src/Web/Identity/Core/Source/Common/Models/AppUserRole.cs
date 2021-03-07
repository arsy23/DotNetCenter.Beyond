namespace DotNetCenter.Beyond.Web.Identity.Core.Common.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DotNetCenter.Core.Entities;
    using System.Text;
    using System.Threading.Tasks;
    using DotNetCenter.Core;

    public class AppUserRole<TKeyUserAndRole>
        : IdentityUserRole<TKeyUserAndRole>, AuditableEntity<TKeyUserAndRole, TKeyUserAndRole>
        where TKeyUserAndRole : IEquatable<TKeyUserAndRole>
    {
        public AppUserRole(TKeyUserAndRole id, DateTime createdDateTime)
        {
            _id = id;
            _createdDateTime = createdDateTime;
        }
        public TKeyUserAndRole LastModifiedBy => _lastModifierId;
        private TKeyUserAndRole _lastModifierId;

        public DateTime? LastModifiedDateTime => throw new NotImplementedException();
        private DateTime? _lastModifiedDateTime;

        public TKeyUserAndRole CreatedBy => _creatorId;
        private readonly TKeyUserAndRole _creatorId;

        public DateTime CreatedDateTime => throw new NotImplementedException();
        private readonly DateTime _createdDateTime;

        public TKeyUserAndRole Id => _id;
        private readonly TKeyUserAndRole _id;

        public void RegisterModifiedInformation(TKeyUserAndRole modifierId, DateTime modifiedDateTime)
        {
            _lastModifierId = modifierId;
            _lastModifiedDateTime = modifiedDateTime;
        }
    }
}
