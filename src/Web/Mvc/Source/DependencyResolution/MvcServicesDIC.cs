namespace DotNetCenter.Beyond.Web.Mvc.DependencyResolution
{
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.DependencyInjection;
    using DotNetCenter.Beyond.Web.Mvc.Core.DependencyResolution;
    public static class MvcServicesDIC
    {
        public static IServiceCollection AddMvcServices(this IServiceCollection services, bool lowercaseUrls)
        {
            var mvcBuilder = services.AddControllersWithViews();
            services.AddSingleton(mvcBuilder);
            services.AddMvcCoreServices(mvcBuilder, lowercaseUrls);
            return services;
        }
    }
}
