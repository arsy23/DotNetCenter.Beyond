namespace DotNetCenter.Beyond.Web.Core.DependencyResolution
{
    using Microsoft.AspNetCore.Routing;
    using Microsoft.Extensions.DependencyInjection;

    public static class RouteServicesDIC
    {
        public static IServiceCollection ConfigureRouteLowercaseUrls(this IServiceCollection services, bool lowercaseUrls)
        {
            services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = lowercaseUrls;
            });
            return services;
        }
    }
}
