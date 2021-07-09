namespace DotNetCenter.Beyond.Web.Core.Common.DIContainerServices.DependencyContainers
{
    using DotNetCenter.Beyond.Web.Core.Common.DIContainerServices.Services;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public static class LoggerProviderDIC
    {
        public static IServiceCollection AddLoggerProviderServices(this IServiceCollection services)
        {
            services.AddSingleton<SupportLoggerProviders, LoggerProviderService>();
            return services;
        }

        public static IServiceCollection TryAddLoggerProviderServices(this IServiceCollection services)
        {
            services.TryAddSingleton<SupportLoggerProviders, LoggerProviderService>();
            return services;
        }
    }
}
