using DotNetCenter.Beyond.Web.Identity.ObjRelMapping.Common.Models;
using DotNetCenter.Beyond.Web.Identity.Services.Managers;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetCenter.Beyond.Web.Identity.Services.DependencyResolution
{
    public static class ManagerServicesDIC
    {
        public static IServiceCollection AddManagerServices<TAppUser, TUserManager, TSignInManager>(this IServiceCollection services)
            where TUserManager : class, UserManagerService<TAppUser>
            where TSignInManager : class, SignInManagerService<TAppUser>
            where TAppUser : IIdentityUser
        {
            services.AddSingleton<UserManagerService<TAppUser>, TUserManager>();
            services.AddSingleton<SignInManagerService<TAppUser>, TSignInManager>();
            return services;
        }
    }
}
