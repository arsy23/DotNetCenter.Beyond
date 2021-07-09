namespace DotNetCenter.Beyond.Web.Projects.Configuration.Core.DIContainerServices
{
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DotNetCenter.Beyond.Web.Projects.Configuration.Core.Interfaces;
    using DotNetCenter.Beyond.Web.Projects.Configuration.Core.Services;
    using Microsoft.Extensions.DependencyInjection.Extensions;

    public static class ConfigurationManagerDIC
    {
        public static IServiceCollection AddConfigurationManagerServices(this IServiceCollection services)
        {
            services
                .AddConfigurationsCoreServices();
            services
                .AddTransient<SupportConfigurationManager, ConfigurationManagerService>()
                .AddTransient<SupportJsonConfigurationManager, JsonConfigurationManagerService>();

            return services;
        }
        public static IServiceCollection TryAddConfigurationManagerServices(this IServiceCollection services)
        {
            services
                .TryAddConfigurationsCoreServices();
            services
                .TryAddTransient<SupportConfigurationManager, ConfigurationManagerService>();
            services
                .TryAddTransient<SupportJsonConfigurationManager, JsonConfigurationManagerService>();

            return services;
        }
    }
}
