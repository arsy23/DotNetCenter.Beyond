namespace DotNetCenter.Beyond.Web.Core.DependencyResolution
{
    using Microsoft.Extensions.DependencyInjection;
    public static class HttpContextServicesConfiguration
    {
        public static IServiceCollection AddHttpContextAccessorService(this IServiceCollection services)
            => services.AddHttpContextAccessor();
    }
}
