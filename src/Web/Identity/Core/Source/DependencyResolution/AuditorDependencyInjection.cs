namespace DotNetCenter.Beyond.Web.Identity.Core.DependencyResolution
{
    using DotNetCenter.Beyond.Web.Identity.Core.Common.DbContextServices;
    using DotNetCenter.Beyond.ObjRelMapping.Core.Auditing;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using DotNetCenter.Core.Entities;
    using DotNetCenter.Beyond.ObjRelMapping.Core.DbContext;
    using DotNetCenter.Beyond.Web.Identity.Core.DbContextServices;

    public static class AuditorDependencyInjection
    {
        public static IServiceCollection AddAuditor(this IServiceCollection services)
        {
            services.AddTransient<Auditable, Auditor>();
            return services;
        }
    }
}
