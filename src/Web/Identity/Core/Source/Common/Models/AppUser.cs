namespace DotNetCenter.Beyond.Web.Identity.Core.Models
{
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

        public virtual bool ValidateUsername()
        {
            if (!string.IsNullOrEmpty(_username))
                return true;

            if (ValidateIdentityUser())
                return true;

            return !string.IsNullOrEmpty(_identityUser.Username);
        }
        public virtual bool ValidateEmail()
        {
            if (!string.IsNullOrEmpty(_email))
                return true;

            if (ValidateIdentityUser())
                return true;

            return !string.IsNullOrEmpty(_identityUser.Email);
        }

        public virtual bool ValidateIdentityUser()
        {
            return TrySetIdentityUser();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public new Guid Id => _id;
        private readonly Guid _id;

        public string PlainPassword => _plainPassword;
        private readonly string _plainPassword;
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

        public DateTime CreatedDateTime => _createdDateTime;
        private readonly DateTime _createdDateTime;

        public string Username => _username;
        private readonly string _username;

        public IdentityUser IdentityUser => _identityUser;
        private IdentityUser _identityUser;
        public string Email => _email;
        private readonly string _email;

        public void RegisterModifiedInformation(Guid modifierId, DateTime modifiedDateTime)
        {
            _lastModifierId = modifierId;
            _lastModifiedDateTime = modifiedDateTime;
        }
        #endregion
        #region GetIdentityUser()
        public virtual bool TrySetIdentityUser()
        {
            if (_identityUser is not null)
                return true;

            var idUser = new IdentityUser(userName: this.Username)
            {
                Id = this.Id.ToString(),
                AccessFailedCount = this.AccessFailedCount,
                TwoFactorEnabled = this.TwoFactorEnabled,
                SecurityStamp = this.SecurityStamp,
                PhoneNumberConfirmed = this.PhoneNumberConfirmed,
                PhoneNumber = this.PhoneNumber,
                PasswordHash = this.PasswordHash,
                Username = this.Username,
                NormalizedEmail = this.NormalizedEmail,
                NormalizedUsername = this.NormalizedUsername,
                ConcurrencyStamp = this.ConcurrencyStamp,
                Email = this.Email,
                EmailConfirmed = this.EmailConfirmed,
                LockoutEnabled = this.LockoutEnabled,
                LockoutEnd = this.LockoutEnd
            };
            try
            {
                _identityUser = idUser;
            }
            catch (InvalidCastException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }

            if (_identityUser is null)
                return false;
            if (string.IsNullOrEmpty(_identityUser.Username))
                return false;

            return true;
        }
        #endregion
    }
}