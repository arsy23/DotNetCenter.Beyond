using Microsoft.AspNetCore.Identity;
using System;

namespace DotNetCenter.Beyond.Web.Identity.Core.Common.Models
{
    public interface IAppUser
    {
        public string ProfilePictureAddress { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DisplayName { get; }

        public string AccountType { get; set; }

        public System.DateTime DateRegistered { get; set; }

        public IdentityUser GetIdentityUser();
    }
}