namespace DotNetCenter.Beyond.Mapping.DependencyResolution
{
    using DotNetCenter.DateTime.DependencyResolution;
    using AutoMapper;
    using Microsoft.Extensions.DependencyInjection;
    using System.Collections.Generic;
    using System.Reflection;

    /// <summary>
    /// AutoMapper Dependency Injection Container
    /// </summary>
    public static class AutoMapperDIC
    { 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static IServiceCollection AddDefaultAutoMapperServices(this IServiceCollection services, Assembly assembly)
        {

            var assemblies = new List<Assembly>();
            assemblies?.AddDotNetCenterDateTimeAssembly();
            assemblies?.Add(assembly);
            if (assemblies is not null)
                services.AddAutoMapper(assemblies);
            return services;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="assemblies"></param>
        /// <returns></returns>
        public static IServiceCollection AddDefaultAutoMapperServices(this IServiceCollection services, List<Assembly> assemblies)
        {

            assemblies?.AddDotNetCenterDateTimeAssembly();
            if (assemblies is not null)
                services.AddAutoMapper(assemblies);
            return services;
        }
        private static List<Assembly>? AddDotNetCenterDateTimeAssembly(this List<Assembly> assemblies)
        {
            var dateTimeAssembly = Assembly.GetAssembly(typeof(DateTimeDIC));
            if (dateTimeAssembly is not null)
                assemblies?.Add(dateTimeAssembly);
            return assemblies;
        }

    }
}
