namespace DotNetCenter.Beyond.Web.Identity.Services.DependencyResolution
{
    using DotNetCenter.Beyond.Web.Identity.ObjRelMapping.Common.Models;
    using DotNetCenter.Beyond.Web.Identity.ObjRelMapping.DbContextServices;
    using Microsoft.Extensions.DependencyInjection;

    public static class IdentityDbServicesDIC
    {
        public static IServiceCollection AddIdentityDbServices<TImplementationDbContext>(this IServiceCollection services)
           where TImplementationDbContext : class, IdentityDbService
        {
            services.AddTransient<IdentityDbService, TImplementationDbContext>();
            services.AddTransient<IIdentityUser, AppUser>();
            services.AddAuditor();
            return services;
        }
    }
}
