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
    public abstract  class BaseAppSignInManager<TKeyUser>
        : SignInManager<AppUser<TKeyUser>> where TKeyUser : IEquatable<TKeyUser>
    {
        protected BaseAppSignInManager(
            UserManager<AppUser<TKeyUser>> userManager,
            IHttpContextAccessor contextAccessor,
            IUserClaimsPrincipalFactory<AppUser<TKeyUser>> claimsFactory,
            IOptions<IdentityOptions> optionsAccessor,
            ILogger<SignInManager<AppUser<TKeyUser>>> logger,
            IAuthenticationSchemeProvider schemes,
            IUserConfirmation<AppUser<TKeyUser>> confirmation) 
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
