namespace DotNetCenter.Beyond.Web.Core.Common.DIContainerServices.DependencyContainers
{
    using DotNetCenter.Beyond.Web.Core.Common.DIContainerServices.Interfaces;
    using DotNetCenter.Beyond.Web.Core.Common.DIContainerServices.Services;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Extensions.DependencyInjection;
    public class AutoMapperDIC
    {
        public IServiceCollection AddAutoMapperServices(ref IServiceCollection services)
        {
            services.AddTransient<SupportAutoMapper, AutoMapperService>();
            return services;
        }
    }
}
