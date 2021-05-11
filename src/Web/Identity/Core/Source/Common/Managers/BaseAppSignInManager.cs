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
    public abstract class BaseAppSignInManager<TKeyUser>
        : SignInManager<IAppUser>
        where TKeyUser : IEquatable<TKeyUser>
    {
        protected BaseAppSignInManager(
            UserManager<IAppUser> userManager,
            IHttpContextAccessor contextAccessor,
            IUserClaimsPrincipalFactory<IAppUser> claimsFactory,
            IOptions<IdentityOptions> optionsAccessor,
            ILogger<SignInManager<IAppUser>> logger,
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
