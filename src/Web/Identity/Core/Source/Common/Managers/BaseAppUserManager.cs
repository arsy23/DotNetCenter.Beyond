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
    public abstract class BaseAppUserManager<TKeyUser, TAppUser>
        : UserManager<TAppUser>
        where TKeyUser : IEquatable<TKeyUser>
        where TAppUser :  AppUser<TKeyUser>
    {
        protected BaseAppUserManager(IUserStore<TAppUser> store,
                                             IOptions<IdentityOptions> optionsAccessor,
                                             IPasswordHasher<TAppUser> passwordHasher,
                                             IEnumerable<IUserValidator<TAppUser>> userValidators,
                                             IEnumerable<IPasswordValidator<TAppUser>> passwordValidators,
                                             ILookupNormalizer keyNObjRelMappingalizer,
                                             IdentityErrorDescriber errors,
                                             IServiceProvider services,
                                             ILogger<UserManager<TAppUser>> logger) 
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
