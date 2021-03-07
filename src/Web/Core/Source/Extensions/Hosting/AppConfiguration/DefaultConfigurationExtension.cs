namespace DotNetCenter.Beyond.Web.Core.Extensions.Hosting
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class DefaultConfigurationExtension
    {
        public static IWebHostBuilder ConfigureDefaultAppConfiguration(
         this IWebHostBuilder host
         , string webHostBuilderBasePath
         , string[] args)
        {
            host
                .ConfigureAppConfiguration((hostContext, configApp) =>
                {
                    configApp.SetBasePath(webHostBuilderBasePath);
                    configApp.AddJsonFile("appsettings.json", optional: true);
                    configApp.AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", optional: true);
                    configApp.AddCommandLine(args);
                });
            return host;
        }
        public static IWebHostBuilder ConfigureJsonConfiguration(
            this IWebHostBuilder host
            , string webHostBuilderBasePath
            , string fileName
            , string[] args)
        {
            host
                .ConfigureAppConfiguration((hostContext, configApp) =>
                {
                    configApp.SetBasePath(webHostBuilderBasePath);
                    configApp.AddJsonFile($"{fileName}.json", optional: true);
                    configApp.AddJsonFile($"{fileName}.{hostContext.HostingEnvironment.EnvironmentName}.json", optional: true);
                    configApp.AddCommandLine(args);
                });
            return host;
        }
    }
}
