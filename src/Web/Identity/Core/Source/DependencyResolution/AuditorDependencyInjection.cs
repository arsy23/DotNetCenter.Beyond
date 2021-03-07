namespace DotNetCenter.Beyond.Web.Identity.Core.DependencyResolution
{
    using DotNetCenter.Beyond.Web.Identity.Core.Common.DbContextServices;
    using DotNetCenter.Beyond.ObjRelMapping.Core.Auditing;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using DotNetCenter.Core.Entities;
    using DotNetCenter.Beyond.ObjRelMapping.Core.DbContext;

    public static class AuditorDependencyInjection
    {
        public static IServiceCollection AddAuditor<TKeyEntity, TKeyUser>(this IServiceCollection services)
            where TKeyUser : struct, IEquatable<TKeyUser>
            where TKeyEntity : struct, IEquatable<TKeyEntity>
        {
            services.AddTransient<Auditable, Auditor<TKeyEntity, TKeyUser>>();
            return services;
        }
    }
}
