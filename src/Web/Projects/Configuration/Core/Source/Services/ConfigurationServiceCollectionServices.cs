namespace DotNetCenter.Beyond.Web.Projects.Configuration.Core.Services
{
    using DotNetCenter.Beyond.Web.Projects.Configuration.Core.Interfaces;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DotNetCenter.Beyond.Web.Core.Extensions;
    using DotNetCenter.Beyond.Web.Projects.Configuration.Core.DIContainerServices;

    public static class ConfigurationServiceCollectionServices
    {
        public static void UpdateGetConfigurationManager(
            this IServiceCollection services,
            out SupportConfigurationManager configurationManagerService)
        {


            services.CreateServiceProviderScope(out var serviceProvider, out var scope);
            services.TryAddConfigurationManagerServices();

            configurationManagerService = serviceProvider
                .GetRequiredService<SupportConfigurationManager>();
        }
    }
}
