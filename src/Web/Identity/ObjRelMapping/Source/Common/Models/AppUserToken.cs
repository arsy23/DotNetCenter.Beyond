namespace DotNetCenter.Beyond.Web.Identity.ObjRelMapping.Common.Models
{
    using DotNetCenter.Beyond.Web.Identity.Infrastructure.SqlServer.Common.Model;
    using Microsoft.AspNetCore.Identity;
    using System;
    public class AppUserToken
        : IdentityUserToken<int>
        , IAppUserToken
    {
    }
}
