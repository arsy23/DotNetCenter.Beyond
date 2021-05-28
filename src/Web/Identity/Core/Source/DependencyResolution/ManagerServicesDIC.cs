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
        public static IServiceCollection AddManagerServices<TUserManager, TSignInManager>(this IServiceCollection services)
            where TUserManager : class, UserManagerService<IAppUser>
            where TSignInManager : class, SignInManagerService<IAppUser>
        {
            services.AddSingleton<UserManagerService<IAppUser>, TUserManager>();
            services.AddSingleton<SignInManagerService<IAppUser>, TSignInManager>();
            return services;
        }
    }
}
