namespace DotNetCenter.Beyond.Web.Core.Common
{
    using DotNetCenter.Beyond.Web.Core.Common.DIContainerServices;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface IAppStartup
    {
        SupportPreConfiguration PreProvidedServices { get; }
        void ConfigureServices(IServiceCollection services);
        void Configure(IApplicationBuilder app);
    }
}
