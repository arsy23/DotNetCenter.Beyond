using Microsoft.Extensions.DependencyInjection;
namespace DotNetCenter.Beyond.Web.Core.DependencyResolution
{
    using Microsoft.AspNetCore.Routing;
    public static class RouteServicesConfiguration
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
