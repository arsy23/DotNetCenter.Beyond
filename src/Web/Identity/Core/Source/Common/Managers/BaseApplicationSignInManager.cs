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
    public abstract  class BaseApplicationSignInManager<TAppKey>
        : SignInManager<AppUser<TAppKey>> where TAppKey : IEquatable<TAppKey>
    {
        protected BaseApplicationSignInManager(
            UserManager<AppUser<TAppKey>> userManager,
            IHttpContextAccessor contextAccessor,
            IUserClaimsPrincipalFactory<AppUser<TAppKey>> claimsFactory,
            IOptions<IdentityOptions> optionsAccessor,
            ILogger<SignInManager<AppUser<TAppKey>>> logger,
            IAuthenticationSchemeProvider schemes,
            IUserConfirmation<AppUser<TAppKey>> confirmation) 
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
