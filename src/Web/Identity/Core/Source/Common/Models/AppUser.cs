namespace DotNetCenter.Beyond.Web.Identity.Core.Models
{
    using DotNetCenter.Core.Entities;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class AppUser : IdentityUser<Guid>
        , IAppUser
    {
        public AppUser(Guid id, DateTime createdDateTime)
        {
            _id = id;
            _createdDateTime = createdDateTime;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public new Guid Id => _id;
        private readonly Guid _id;
        public string ProfilePictureAddress { get; protected set; } = "/user/images/profile/default.png";
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string DisplayName { get; protected set; }
        public string AccountType { get; protected set; }
        public DateTime DateRegistered { get; protected set; }
        public string Tag { get; protected set; }

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
        #region GetIdentityUser()
        public virtual IdentityUser GetIdentityUser()
        {
            var idUser = new IdentityUser(userName: this.UserName)
            {
                Id = this.Id.ToString(),
                AccessFailedCount = this.AccessFailedCount,
                TwoFactorEnabled = this.TwoFactorEnabled,
                SecurityStamp = this.SecurityStamp,
                PhoneNumberConfirmed = this.PhoneNumberConfirmed,
                PhoneNumber = this.PhoneNumber,
                PasswordHash = this.PasswordHash,
                UserName = this.UserName,
                NormalizedEmail = this.NormalizedEmail,
                NormalizedUserName = this.NormalizedUserName,
                ConcurrencyStamp = this.ConcurrencyStamp,
                Email = this.Email,
                EmailConfirmed = this.EmailConfirmed,
                LockoutEnabled = this.LockoutEnabled,
                LockoutEnd = this.LockoutEnd
            };
            return (IdentityUser)idUser;
        }
        #endregion
    }
}