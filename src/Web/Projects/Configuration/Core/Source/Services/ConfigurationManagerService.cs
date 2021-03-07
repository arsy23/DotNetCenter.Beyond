namespace DotNetCenter.Beyond.Web.Projects.Configuration.Core.Services
{
    using DotNetCenter.Beyond.Web.Core.Common.DIContainerServices.Interfaces;
    using DotNetCenter.Beyond.Web.Core.Common.DIContainerServices.Services;
    using DotNetCenter.Beyond.Web.Projects.Configuration.Core.Interfaces;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Configuration;
    using System.IO;
    using Microsoft.AspNetCore.Hosting;
    public class ConfigurationManagerService 
        : BaseConfigService
        , SupportConfigurationManager
    {
        public ConfigurationManagerService(
            SupportJsonConfigurationManager jsonConfigurationManagerService
            , SupportConfiguration configurationService
            , SupportWebHosting webHostingService)
            :base(configurationService, webHostingService)
        {
            _jsonConfigurationManagerService = jsonConfigurationManagerService;
        }
        public SupportJsonConfigurationManager JsonConfigurationManagerService => _jsonConfigurationManagerService;
        private SupportJsonConfigurationManager _jsonConfigurationManagerService;

        //public void AddJsonConfiguration(
        //    ref IServiceCollection services,
        //    string configurationBasePath,
        //    string fileName,
        //    string[] args)
        //{

        //    ConfigurationBuilderService
        //    .ConfigurationBuilder
        //    .SetBasePath(configurationBasePath)
        //        .AddJsonFile($"{fileName}.json", optional: true)
        //        .AddJsonFile($"{fileName}.{GetWebHostEnvName()}.json", optional: true)
        //        .AddCommandLine(args);

        //    ConfigurationBuilderService
        //        .ConfigurationBuilder
        //        .Build();

        //    services
        //        .CreateServiceProviderScope(out var serviceProvider, out var scope);

        //    _jsonConfigurationManagerService =
        //        serviceProvider
        //        .GetRequiredService<SupportJsonConfigurationManager>();

        //}

        public IWebHostEnvironment GetWebHostEnvService() 
            => WebHostingService
                .WebHostEnvService;
        public string GetWebHostEnvName()
            => GetWebHostEnvService()
            .EnvironmentName;
    }
}
