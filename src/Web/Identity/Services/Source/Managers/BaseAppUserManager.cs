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
    using DotNetCenter.Beyond.Web.Identity.Core.Models;
    using DotNetCenter.Beyond.Web.Identity.Core;
    using DotNetCenter.Core.ErrorHandlers;
    using DotNetCenter.Beyond.Web.Identity.Core.Managers;

    public abstract class BaseAppUserManager
        : UserManager<IAppUser>, UserManagerService<IAppUser>
    {
        protected BaseAppUserManager(IUserStore<IAppUser> store,
                                             IOptions<IdentityOptions> optionsAccessor,
                                             IPasswordHasher<IAppUser> passwordHasher,
                                             IEnumerable<IUserValidator<IAppUser>> userValidators,
                                             IEnumerable<IPasswordValidator<IAppUser>> passwordValidators,
                                             ILookupNormalizer keyNObjRelMappingalizer,
                                             IdentityErrorDescriber errors,
                                             IServiceProvider services,
                                             ILogger<BaseAppUserManager> logger) 
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
        public new async Task<ResultContainer> CreateAsync(IAppUser user)
        {
           var idResult = await base.CreateAsync(user);
            return idResult.ToApplicationResult();
        }
    }
}
