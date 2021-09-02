namespace DotNetCenter.Beyond.Web.Identity.Services.Managers
{
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
    using DotNetCenter.Beyond.Web.Identity.Core;
    using DotNetCenter.Core.ErrorHandlers;
    using DotNetCenter.Beyond.Web.Identity.ObjRelMapping.Common.Models;

    public abstract class BaseAppUserManager<TAppUser>
        : UserManager<TAppUser>, UserManagerService<TAppUser>
        #region Constraints
        //dc#1#  developer: development cases
        //Case 2 : For SwitchContects internal 
        where TAppUser : AppUser
        //Case 1 : For SwitchContects of Code To Generic Types 
        //where TAppUser : class, IAppUser
        #endregion
    {
        protected BaseAppUserManager(IUserStore<TAppUser> store,
                                             IOptions<IdentityOptions> optionsAccessor,
                                             IPasswordHasher<TAppUser> passwordHasher,
                                             IEnumerable<IUserValidator<TAppUser>> userValidators,
                                             IEnumerable<IPasswordValidator<TAppUser>> passwordValidators,
                                             ILookupNormalizer keyNObjRelMappingalizer,
                                             IdentityErrorDescriber errors,
                                             IServiceProvider services,
                                             ILogger<BaseAppUserManager<TAppUser>> logger) 
            : base(store,
                   optionsAccessor,
                   passwordHasher,
                   userValidators,
                   passwordValidators,
                   keyNObjRelMappingalizer,
                   errors,
                   services,
                   logger)
        {
        }
        public new async Task<ResultContainer> CreateAsync(TAppUser user)
        {
           var idResult = await base.CreateAsync(user);
            return idResult.ToApplicationResult();
        }
    }
}
