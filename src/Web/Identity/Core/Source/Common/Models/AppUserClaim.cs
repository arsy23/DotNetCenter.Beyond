namespace DotNetCenter.Beyond.Web.Identity.Core.Models
{
    using System;
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class AppUserClaim
        : IdentityUserClaim<Guid>
        , IAppUserClaim
    {
    }
}
