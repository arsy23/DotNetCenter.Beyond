using DotNetCenter.Beyond.Web.Core.Common.DIContainerServices;
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
    public abstract class BaseAppStartup : IAppStartup
    {
        public BaseAppStartup(SupportPreConfiguration providedServices) 
            => _preProvidedServices = providedServices;

        public SupportPreConfiguration PreProvidedServices => _preProvidedServices;
        private readonly SupportPreConfiguration _preProvidedServices;
        public abstract void ConfigureServices(IServiceCollection services);
        public abstract void Configure(IApplicationBuilder app);
    }
}
