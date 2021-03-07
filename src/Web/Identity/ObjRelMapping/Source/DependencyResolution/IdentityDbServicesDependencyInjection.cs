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
    public static class IdentityDbServicesDependencyInjection
    {
       public static IServiceCollection AddIdentityDbServices<TServiceDbContext, TImplementationDbContext, TKeyEntity, TKeyUser>(this IServiceCollection services)
          where TKeyEntity : struct, IEquatable<TKeyEntity>
          where TKeyUser : struct, IEquatable<TKeyUser>
          where TServiceDbContext : IdentityDbService
          where TImplementationDbContext : class, IdentityDbService
        {
            services.AddTransient<IdentityDbService, TImplementationDbContext>();
            services.AddAuditor<TKeyEntity, TKeyUser>();
            return services;
        }
    }
}
