namespace DotNetCenter.Beyond.Web.Identity.Core.Common.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class AppRoleClaim<TKeyRole>
        : IdentityRoleClaim<TKeyRole> where TKeyRole : IEquatable<TKeyRole>
    {
    }
}
