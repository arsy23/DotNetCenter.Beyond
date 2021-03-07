namespace DotNetCenter.Beyond.Mediation.DependencyResolution
{
    using global::MediatR;
    using Microsoft.Extensions.DependencyInjection;
    using System.Reflection;
    using DotNetCenter.Beyond.Mediation.Behaviours.DependencyResolution;
    using System.Collections.Generic;

    public static class MediationDIC
    { 
        public static IServiceCollection AddBehaviouralMediation(this IServiceCollection services, Assembly assembly)
        {
            services.AddMediatR(assembly);
            services.AddRequestBehaviours();
            return services;
        }
        public static IServiceCollection AddBehaviouralMediation(this IServiceCollection services, List<Assembly> assembly)
        {
            services.AddMediatR(assembly.ToArray());
            services.AddRequestBehaviours();
            return services;
        }
        public static IServiceCollection AddDefaultMediationServices(this IServiceCollection services, Assembly assembly)
        {
            services.AddMediatR(assembly);
            return services;
        }
        public static IServiceCollection AddDefaultMediationServices(this IServiceCollection services, List<Assembly> assembly)
        {
            services.AddMediatR(assembly.ToArray());
            return services;
        }
    }
}
