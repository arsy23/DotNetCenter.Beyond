namespace DotNetCenter.Beyond.Web.Identity.Core.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class AppRoleClaim
        : IdentityRoleClaim<Guid>
        , IAppRoleClaim
    {
    }
}
