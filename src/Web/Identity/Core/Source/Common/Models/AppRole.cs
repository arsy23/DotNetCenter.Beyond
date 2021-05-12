namespace DotNetCenter.Beyond.Web.Identity.Core.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    public class AppRole
        : IdentityRole<Guid>
        , IAppRole
    { 
        public AppRole() { }
        public AppRole(string name) 
            => Name = name;
        public AppRole(string name, string _description)
        {
            Name = name;
            Description = _description;
        }
        public string Description { get; protected set; }
        public string Tag { get; protected set;}

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
