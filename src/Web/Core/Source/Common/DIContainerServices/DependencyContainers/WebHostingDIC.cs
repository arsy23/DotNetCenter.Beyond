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
    public static class WebHostingDIC
    {
        public static IServiceCollection AddWebHostingServices(this IServiceCollection services)
        {
            services.AddSingleton<IWebHostEnvironmentServiceWrapper, WebHostingServiceWrapper>();
            services.AddSingleton<SupportWebHosting, WebHostingService>();
            return services;
        }

        public static IServiceCollection TryAddWebHostingServices(this IServiceCollection services)
        {
            services.TryAddSingleton<IWebHostEnvironmentServiceWrapper, WebHostingServiceWrapper>();
            services.TryAddSingleton<SupportWebHosting, WebHostingService>();
            return services;
        }
    }
}
