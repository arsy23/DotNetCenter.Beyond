namespace DotNetCenter.Beyond.Web.Core.DependencyResolution
{
    using DotNetCenter.Beyond.Web.Core.Common.DIContainerServices.DependencyContainers;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public static class CoreServicesConfiguration
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services, bool lowercaseUrls)
        {
            services.AddHttpContextAccessorService();

            new AllDICies()
                .AddAllDICServices(ref services);

            services.AddModelValidation();

            services.ConfigureRouteLowercaseUrls(lowercaseUrls);

            var environment = services.BuildServiceProvider().GetRequiredService<IHostEnvironment>();
            if (environment.IsDevelopment())
            {
#if NET5_0
                services.AddDatabaseDeveloperPageExceptionFilter();
#endif 
            }
            return services;
        }
    }
}
