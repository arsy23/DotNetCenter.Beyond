namespace DotNetCenter.Beyond.Web.Identity.Core.Common.Managers
{
    using DotNetCenter.Beyond.Web.Identity.Core.Common.Models;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public abstract class BaseAppSignInManager<TKeyUser, TAppUser>
        : SignInManager<TAppUser>
        where TKeyUser : IEquatable<TKeyUser>
        where TAppUser : AppUser<TKeyUser>
    {
        protected BaseAppSignInManager(
            UserManager<TAppUser> userManager,
            IHttpContextAccessor contextAccessor,
            IUserClaimsPrincipalFactory<TAppUser> claimsFactory,
            IOptions<IdentityOptions> optionsAccessor,
            ILogger<SignInManager<TAppUser>> logger,
            IAuthenticationSchemeProvider schemes,
            IUserConfirmation<TAppUser> confirmation) 
            : base(
                  userManager,
                  contextAccessor,
                  claimsFactory,
                  optionsAccessor,
                  logger,
                  schemes,
                  confirmation)
        {
        }
    }
}
