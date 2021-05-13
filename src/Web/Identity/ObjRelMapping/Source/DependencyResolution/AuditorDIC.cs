namespace DotNetCenter.Beyond.Web.Identity.ObjRelMapping.DependencyResolution
{
    using Microsoft.Extensions.DependencyInjection;
    using DotNetCenter.Beyond.Web.Identity.ObjRelMapping.DbContextServices;
    using DotNetCenter.Beyond.ObjRelMapping.Core.Auditing;
    public static class AuditorDIC
    {
        public static IServiceCollection AddAuditor(this IServiceCollection services)
        {
            services.AddTransient<Auditable, Auditor>();
            return services;
        }
    }
}
