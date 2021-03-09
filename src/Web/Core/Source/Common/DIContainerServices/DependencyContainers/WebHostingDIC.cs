namespace DotNetCenter.Beyond.Web.Core.Common.DIContainerServices.DependencyContainers
{
    using DotNetCenter.Beyond.Web.Core.Common.DIContainerServices.Interfaces;
    using DotNetCenter.Beyond.Web.Core.Common.DIContainerServices.Services;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public static class WebHostingDIC
    {
        public static IServiceCollection AddWebHostingService(this IServiceCollection services)
        {
            services.AddSingleton<SupportWebHosting, WebHostingService>();
            return services;
        }
    }
}
