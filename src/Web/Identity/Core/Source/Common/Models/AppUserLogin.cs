namespace DotNetCenter.Beyond.Web.Identity.Core.Common.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using DotNetCenter.Core.Entities;
    using System.Threading.Tasks;
    using DotNetCenter.Core;

    public class AppUserLogin<TKeyUser> 
        : IdentityUserLogin<TKeyUser>
        where TKeyUser : IEquatable<TKeyUser>
    {
    }
}
