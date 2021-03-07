namespace DotNetCenter.Beyond.Web.Mvc.Core.DependencyResolution
{
    using DotNetCenter.Beyond.Web.Core.FilterAttributes;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public static class ExceptionHandlersDIC
    {
        public static IServiceCollection ConfigureDomainExceptionFilterService(this IServiceCollection services)
        {
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add<ExceptionFilter>();
            });
            return services;
        }
    }
}
