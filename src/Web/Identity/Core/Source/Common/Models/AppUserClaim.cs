namespace DotNetCenter.Beyond.Web.Identity.Core.Common.Models
{
    using System;
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class AppUserClaim<TKeyUser> 
        : IdentityUserClaim<TKeyUser> where TKeyUser : IEquatable<TKeyUser>
    {
    }
}
