namespace DotNetCenter.Beyond.Web.Identity.Services.Managers
{
    using DotNetCenter.Beyond.Web.Identity.ObjRelMapping.Common.Models;
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
    public abstract class BaseAppSignInManager<TAppUser>
        : SignInManager<TAppUser>, SignInManagerService<TAppUser>
        #region Constraints
        //dc#1#  developer: development cases
        //Case 2 : For SwitchContects internal 
        where TAppUser : AppUser
        //Case 1 : For SwitchContects of Code To Generic Types 
        //where TAppUser : class, IAppUser
        #endregion
    {
        protected BaseAppSignInManager(
            UserManager<TAppUser> userManager,
            IHttpContextAccessor contextAccessor,
            IUserClaimsPrincipalFactory<TAppUser> claimsFactory,
            IOptions<IdentityOptions> optionsAccessor,
            ILogger<BaseAppSignInManager<TAppUser>> logger,
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
