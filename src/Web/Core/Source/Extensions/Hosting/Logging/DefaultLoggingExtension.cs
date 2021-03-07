namespace DotNetCenter.Beyond.Web.Core.Extensions.Hosting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Logging;
    public static class DefaultLoggingExtension
    {
        public static IWebHostBuilder ConfigureDefaultLogging(
                                                        this IWebHostBuilder host
                                                        , string configurationSection = "Logging")
        {
            host
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConfiguration(hostingContext.Configuration.GetSection(configurationSection));
                    logging.AddConsole();
                    logging.AddDebug();
                });
            return host;
        }
    }
}
