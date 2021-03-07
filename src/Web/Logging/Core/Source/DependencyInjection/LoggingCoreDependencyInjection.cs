namespace DotNetCenter.Beyond.Web.Logging.Core.DependencyInjection
{
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class LoggingCoreDependencyInjection
    {
        public static IServiceCollection AddDefaultCoreLoggingService(this IServiceCollection services)
        {
            return services;
        }
    }
}
