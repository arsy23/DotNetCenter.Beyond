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
    public abstract class BaseAppUserManager<TKeyUser>
        : UserManager<AppUser<TKeyUser>> where TKeyUser : IEquatable<TKeyUser>
    {
        protected BaseAppUserManager(IUserStore<AppUser<TKeyUser>> store,
                                             IOptions<IdentityOptions> optionsAccessor,
                                             IPasswordHasher<AppUser<TKeyUser>> passwordHasher,
                                             IEnumerable<IUserValidator<AppUser<TKeyUser>>> userValidators,
                                             IEnumerable<IPasswordValidator<AppUser<TKeyUser>>> passwordValidators,
                                             ILookupNormalizer keyNObjRelMappingalizer,
                                             IdentityErrorDescriber errors,
                                             IServiceProvider services,
                                             ILogger<UserManager<AppUser<TKeyUser>>> logger) 
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
