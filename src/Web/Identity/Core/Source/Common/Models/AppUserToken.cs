namespace DotNetCenter.Beyond.Web.Identity.Core.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    public class AppUserToken
        : IdentityUserToken<Guid>
        , IAppUserToken
    {
    }
}
