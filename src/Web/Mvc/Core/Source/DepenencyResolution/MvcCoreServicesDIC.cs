namespace DotNetCenter.Beyond.Web.Mvc.Core.DependencyResolution
{
    using Microsoft.Extensions.DependencyInjection;
    using DotNetCenter.Beyond.Web.Core.DependencyResolution;
    public static class MvcCoreServicesDIC
    {
        public static IMvcBuilder AddMvcCoreServices(this IServiceCollection services,
                                                     IMvcBuilder mvcBuilder,
                                                     bool lowercaseUrls)
        {
            services.AddCoreServices(lowercaseUrls);
            services.ConfigureDomainExceptionFilterService();
            services.AddSingleton(mvcBuilder);
            return mvcBuilder;
        }
    }
}
