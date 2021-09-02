
namespace DotNetCenter.Beyond.Web.Identity.ObjRelMapping.Common.Models
{
    using DotNetCenter.Beyond.ObjRelMapping.Core.Infrastructure.Common;
    using DotNetCenter.Core.Entities;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;

    public interface IIdentityUser: IAppUser<int, Guid>
    {
        public string Tag { get; }
        public string UserName { get; }
        public string Email { get; }
        public string DisplayName { get; }
        //public bool ValidateIdentityUser();
    }
}