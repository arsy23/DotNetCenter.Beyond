namespace DotNetCenter.Beyond.Web.Identity.Services.DependencyResolution
{
    using DotNetCenter.Beyond.Web.Identity.Core;
    using DotNetCenter.Beyond.Web.Identity.Services;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public static class IdentityServicesDIC
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        { 
            return services;
        }
    }
}
