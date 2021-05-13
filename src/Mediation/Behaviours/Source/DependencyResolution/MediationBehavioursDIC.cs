namespace DotNetCenter.Beyond.Mediation.Behaviours.DependencyResolution
{
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    using System.Reflection;
    public static class RequestBehavioursDIC
    { 
        public static IServiceCollection AddRequestBehaviours(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerfObjRelMappinganceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            return services;
        }
    }
}
