namespace DotNetCenter.Beyond.Web.Identity.Core.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;

    public class AppUserRole
        : IdentityUserRole<Guid>
        , IAppUserRole
    {
        public AppUserRole(int id, DateTime createdDateTime)
        {
            _id = id;
            _createdDateTime = createdDateTime;
        }
        public int Id { get => _id; }
        private readonly int _id;

        #region Audit
        public Guid LastModifiedBy => _lastModifierId;
        private Guid _lastModifierId;

        public DateTime? LastModifiedDateTime => throw new NotImplementedException();
        private DateTime? _lastModifiedDateTime;

        public Guid CreatedBy => _creatorId;
        private readonly Guid _creatorId;

        public DateTime CreatedDateTime => throw new NotImplementedException();

        private readonly DateTime _createdDateTime;

        public void RegisterModifiedInformation(Guid modifierId, DateTime modifiedDateTime)
        {
            _lastModifierId = modifierId;
            _lastModifiedDateTime = modifiedDateTime;
        }
        #endregion
    }
}
