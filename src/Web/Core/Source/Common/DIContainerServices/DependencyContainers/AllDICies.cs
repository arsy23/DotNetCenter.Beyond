namespace DotNetCenter.Beyond.Web.Core.Common.DIContainerServices.DependencyContainers
{
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AllDICies
    {
        public IServiceCollection AddAllDICServices(ref IServiceCollection services)
        {
            new HttpContextDIC()
                .AddHttpContextServices(ref services);

            new AspNetCoreDIC()
                .AddAspNetCoreService(ref services);

            new AutoMapperDIC()
                .AddAutoMapperServices(ref services);

            new MediatRDIC()
                .AddMediatRServices(ref services);

            new AllDotNetCenterDIC()
                .AddAllDotNetCenterDICServices(ref services);
            return services;
        }
    }
}
