namespace DotNetCenter.Beyond.Web.Api.DependencyResolution
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using DotNetCenter.Beyond.Web.Core.DependencyResolution;

    public static class WebApiServicesConfiguration
    {
        public static IServiceCollection AddWebApiServices(this IServiceCollection services, Action<MvcOptions> options, bool lowercaseUrls)
        {
            services.AddCoreServices(lowercaseUrls);
            var mvcBuilder = services.AddControllers(options);
            services.AddSingleton(mvcBuilder);
            return services;
        }
    }
}
