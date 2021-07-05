using DotNetCenter.Beyond.Web.Core.Common.DIContainerServices.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCenter.Beyond.Web.Core.Common
{
    public abstract class BaseAppStartup : IAppStartup<SupportConfiguration, SupportWebHosting, ILoggerFactory>
    {
        public BaseAppStartup(SupportConfiguration configuration, SupportWebHosting webHosting, ILoggerFactory logger)
        {
            Configuration = configuration;
            WebHosting = webHosting;
            LoggerFactory = logger;
        }
        public SupportConfiguration Configuration { get; }
        public SupportWebHosting WebHosting { get; }
        public ILoggerFactory LoggerFactory { get; }
        public abstract void ConfigureServices(IServiceCollection services);
        public abstract void Configure(IApplicationBuilder app);
    }
}
