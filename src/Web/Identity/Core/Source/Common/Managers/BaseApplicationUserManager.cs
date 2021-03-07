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
    using DotNetCenter.Beyond.Web.Identity.Core.Common.Models;
    public abstract  class BaseApplicationUserManager<TAppKey>
        : UserManager<AppUser<TAppKey>> where TAppKey : IEquatable<TAppKey>
    {
        protected BaseApplicationUserManager(IUserStore<AppUser<TAppKey>> store,
                                             IOptions<IdentityOptions> optionsAccessor,
                                             IPasswordHasher<AppUser<TAppKey>> passwordHasher,
                                             IEnumerable<IUserValidator<AppUser<TAppKey>>> userValidators,
                                             IEnumerable<IPasswordValidator<AppUser<TAppKey>>> passwordValidators,
                                             ILookupNormalizer keyNObjRelMappingalizer,
                                             IdentityErrorDescriber errors,
                                             IServiceProvider services,
                                             ILogger<UserManager<AppUser<TAppKey>>> logger) 
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
    }
}
