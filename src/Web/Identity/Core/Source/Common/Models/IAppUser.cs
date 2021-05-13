﻿
namespace DotNetCenter.Beyond.Web.Identity.Core.Models
{
    using DotNetCenter.Core.Entities;
    using Microsoft.AspNetCore.Identity;
    using System;

    public interface IAppUser : AuditableEntity<Guid, Guid>
        , TrackableEntity
    {
        public string Tag { get; }
        public string ProfilePictureAddress { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string DisplayName { get; }
        public string AccountType { get; }
        public System.DateTime DateRegistered { get; }
        public IdentityUser GetIdentityUser();
    }
}