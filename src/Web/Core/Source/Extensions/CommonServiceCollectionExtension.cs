namespace DotNetCenter.Beyond.Web.Core.Extensions
{
    using DotNetCenter.Beyond.Web.Core.Common.DIContainerServices;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public static class CommonServiceCollectionExtension
    {
        public static SupportWebHosting GetWebHostingService(this IServiceCollection services)
        {
            CommonServiceCollectionExtension
                .BuildGetServiceProvider(services,
                                            out var serviceProvider);
            return serviceProvider
                .GetRequiredService<SupportWebHosting>();
        }

        public static void BuildGetServiceProvider(this IServiceCollection services, out IServiceProvider serviceProvider)
            => serviceProvider = services.BuildServiceProvider();
        public static void CreateServiceProviderScope(this IServiceCollection services, out IServiceProvider serviceProvider, out IServiceScope scope)
        {
            serviceProvider = services.BuildServiceProvider();
            scope = serviceProvider.CreateScope();
        }
        public static void BuildGetServiceProviderScope(this IServiceCollection services, out IServiceScope scope)
        {
            var serviceProvider = services.BuildServiceProvider();
            scope = serviceProvider.CreateScope();
        }
        public static TService GetAppRequiredService<TService>(this IServiceCollection services)
        {
            BuildGetServiceProvider(services, out var serviceProvider);
            return serviceProvider
            .GetRequiredService<TService>();
        }
        public static void UpdateGetConfiguration(this IServiceCollection services, out SupportConfiguration configurationService)
        {
            services.BuildGetServiceProvider(out var serviceProvider);
            configurationService = serviceProvider
                .GetRequiredService<SupportConfiguration>();
        }
        public static void UpdateGetConfiguration(this IServiceCollection services, out IConfiguration configuration)
        {
            services.BuildGetServiceProvider(out var serviceProvider);
            configuration = serviceProvider
                .GetRequiredService<IConfiguration>();
        }
        public static void UpdateGetWebHosting(this IServiceCollection services, out SupportWebHosting configurationService)
        {
            services.BuildGetServiceProvider(out var serviceProvider);
            configurationService = serviceProvider
                .GetRequiredService<SupportWebHosting>();
        }
    }
}
