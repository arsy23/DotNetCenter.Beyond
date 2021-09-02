namespace DotNetCenter.Beyond.Web.Identity.ObjRelMapping.Common.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;

    public class AppUserLogin
        : IdentityUserLogin<int>
        , IAppUserLogin
    {
    }
}
