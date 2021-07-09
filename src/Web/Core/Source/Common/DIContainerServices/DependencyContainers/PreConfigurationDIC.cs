using DotNetCenter.Beyond.Web.Core.Common.DIContainerServices.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetCenter.Beyond.Web.Core.Common.DIContainerServices.DependencyContainers
{
    public class PreConfigurationDIC
    {
        public IServiceCollection AddWebPreConfigurations(ref IServiceCollection services)
        {

            services.AddWebHostingServices();
            services.AddLoggerProviderServices();
            services.AddSingleton<SupportConfiguration, ConfigurationService>();
            services.AddSingleton<SupportPreConfiguration, PreConfigurationService>();
            return services;
        }
    }
}
