namespace DotNetCenter.Beyond.Web.Identity.Core.Common.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;

    public class AppUser<TKeyUser> : IdentityUser<TKeyUser>, IAppUser
        where TKeyUser : IEquatable<TKeyUser>
    {
        public AppUser()
        { }

        public string ProfilePictureAddress { get; set; } = "/user/images/profile/default.png";

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DisplayName { get; }

        public string AccountType { get; set; }

        public DateTime DateRegistered { get; set; }

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
    }
}