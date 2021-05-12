namespace DotNetCenter.Beyond.Web.Identity.ObjRelMapping.DependencyResolution
{
    using DotNetCenter.Beyond.Web.Identity.Core;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DotNetCenter.Beyond.Web.Identity.Core.DependencyResolution;
    using DotNetCenter.Beyond.Web.Identity.Core.DbContextServices;

    public static class IdentityDbServicesDependencyInjection
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
