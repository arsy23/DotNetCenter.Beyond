namespace DotNetCenter.Beyond.Web.Mvc.RazorPages.DependencyResolution
{
    using Microsoft.Extensions.DependencyInjection;
    using DotNetCenter.Beyond.Web.Mvc.Core.DependencyResolution;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System;
    using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
    using DotNetCenter.Beyond.Web.Mvc.DependencyResolution;

    public static class RazorPagesServicesDIC
    {
        public static IServiceCollection AddRazorPagesServices(this IServiceCollection services,
                                                               Action<RazorPagesOptions> options,
                                                               bool lowercaseUrl)
        {
            services.AddMvcServices(lowercaseUrl);
            var mvcBuilder = services.AddRazorPages(options);
            mvcBuilder.AddSessionStateTempDataProvider();
            mvcBuilder.AddRazorRuntimeCompilation();
            services.AddSingleton(mvcBuilder);
            return services;
        }
    }
}
