namespace DotNetCenter.Beyond.Web.Identity.Core.Common.Models
{
    using DotNetCenter.Core;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class AppUserToken<TKeyUser> 
        : IdentityUserToken<TKeyUser> 
        where TKeyUser : IEquatable<TKeyUser>
    {
    }
}
