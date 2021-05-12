namespace DotNetCenter.Beyond.Web.Identity.Core.Common.Managers
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

    public abstract class BaseAppUserManager
        : UserManager<IAppUser>, UserManagerService
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
        public override Task<IdentityResult> CreateAsync(IAppUser user)
        {
            return base.CreateAsync(user);
        }
    }
}
