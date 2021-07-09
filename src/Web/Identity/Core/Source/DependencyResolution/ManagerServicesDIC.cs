using DotNetCenter.Beyond.Web.Identity.Core.Managers;
using DotNetCenter.Beyond.Web.Identity.Core.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCenter.Beyond.Web.Identity.Core.DependencyResolution
{
    public static class ManagerServicesDIC
    {
        public static IServiceCollection AddManagerServices<TAppUser, TUserManager, TSignInManager>(this IServiceCollection services)
            where TUserManager : class, UserManagerService<TAppUser>
            where TSignInManager : class, SignInManagerService<TAppUser>
            where TAppUser : AppUser
        {
            services.AddSingleton<UserManagerService<TAppUser>, TUserManager>();
            services.AddSingleton<SignInManagerService<TAppUser>, TSignInManager>();
            return services;
        }
    }
}
