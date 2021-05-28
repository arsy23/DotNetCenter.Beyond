namespace DotNetCenter.Beyond.Web.Identity.Services.Managers
{
    using DotNetCenter.Beyond.Web.Identity.Core.Managers;
    using DotNetCenter.Beyond.Web.Identity.Core.Models;
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
    public abstract class BaseAppSignInManager
        : SignInManager<IAppUser>, SignInManagerService<IAppUser>
    {
        protected BaseAppSignInManager(
            UserManager<IAppUser> userManager,
            IHttpContextAccessor contextAccessor,
            IUserClaimsPrincipalFactory<IAppUser> claimsFactory,
            IOptions<IdentityOptions> optionsAccessor,
            ILogger<BaseAppSignInManager> logger,
            IAuthenticationSchemeProvider schemes,
            IUserConfirmation<IAppUser> confirmation) 
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
