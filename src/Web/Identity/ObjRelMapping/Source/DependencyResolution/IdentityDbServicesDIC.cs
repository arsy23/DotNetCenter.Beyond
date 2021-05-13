namespace DotNetCenter.Beyond.Web.Identity.ObjRelMapping.DependencyResolution
{
    using DotNetCenter.Beyond.Web.Identity.ObjRelMapping.DbContextServices;
    using Microsoft.Extensions.DependencyInjection;

    public static class IdentityDbServicesDIC
    {
        public static IServiceCollection AddIdentityDbServices<TServiceDbContext, TImplementationDbContext>(this IServiceCollection services)
           where TServiceDbContext : IdentityDbService
           where TImplementationDbContext : class, IdentityDbService
        {
            services.AddTransient<IdentityDbService, TImplementationDbContext>();
            services.AddAuditor();
            return services;
        }
    }
}
