namespace DotNetCenter.Beyond.Web.Core.DependencyResolution
{
    using DotNetCenter.Beyond.Web.Core.FilterAttributes;
    using Microsoft.Extensions.DependencyInjection;
    public static class ModelValidationConfiguration
    {
        public static IServiceCollection AddModelValidation(this IServiceCollection services)
            => services.AddScoped<ModelValidationAttribute>();
    }
}
