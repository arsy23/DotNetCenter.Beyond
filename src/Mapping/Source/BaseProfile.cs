namespace DotNetCenter.Beyond.Mapping
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    public class BaseProfile : Profile
    {
        // For custom mapping and when this assembly scaned this base profile confused with this base class with other mapping profiles in this assembly
        //This code show exception for imapto if the objects inheriet from a generic type and that generic type again inheriet as parent of another type that inheriet to object
        //Like -> Example : BaseClass, IAuditable, IMapTo<SomeEntity>
        //BaseClass : IBaseEntity<Guid>
        //IAuditale : IBaseEntity<Guid>
        public BaseProfile()
        { }
        public BaseProfile(Assembly executingAssembly) 
            => ApplyMappingsFromAssembly(executingAssembly);
        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
             _ = InvokeIMapFrom(assembly);
            InvokeIMapTo(assembly);
        }

        private void InvokeIMapTo(Assembly assembly)
        {
            foreach (var type in GetIMapToExportedTypes(assembly))
                    InvokeMappingMethodImplementationForIMapTo(type);
        }
        private bool InvokeIMapFrom(Assembly assembly)
        {
            var invoked = false;
            foreach (var type in GetIMapFromExportedTypes(assembly))
            {
                invoked = InvokeMappingMethodForIMapFrom(type);
                if (invoked) 
                return true;
            }
            return invoked;
        }
        private bool InvokeMappingMethodForIMapFrom(Type type)
        {
            var instance = Activator.CreateInstance(type);
            var invoked = false;
            if (!TryInvokeClassMethodImplementation(type, instance))
                invoked = TryInvokeInterfacMethodImplementation(GetMapFromInterfaces(type), instance);
            else if(TryInvokeClassMethodImplementation(type, instance))
                return true;
            return invoked;
        }
        private void InvokeMappingMethodImplementationForIMapTo(Type type)
        {
            var instance = Activator.CreateInstance(type);
            if (!TryInvokeClassMethodImplementation(type, instance))
                TryInvokeInterfacMethodImplementation(GetMapToInterfaces(type), instance);
        }
        private bool TryInvokeClassMethodImplementation(Type type, object instance)
        {
            var methodInfo = type?.GetMethod("Mapping");
            if (methodInfo is null)
                return false;
            methodInfo.Invoke(instance, new object[] { this });
            return true;
        }

        private static IEnumerable<Type> GetMapToInterfaces(Type type) => type.GetInterfaces().Where(o => o.IsGenericType && o.GetGenericTypeDefinition() == typeof(IMapTo<>));
        private static List<Type> GetMapFromInterfaces(Type type) => type.GetInterfaces().Where(o => o.GetGenericTypeDefinition() == typeof(IMapFrom<>) && o.IsGenericType).ToList();
        private static List<Type> GetIMapFromExportedTypes(Assembly assembly) => assembly.GetExportedTypes()
            .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
            .ToList();
        private static List<Type> GetIMapToExportedTypes(Assembly assembly) => assembly.GetExportedTypes()
            .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapTo<>)))
            .ToList();

        private bool TryInvokeInterfacMethodImplementation(IEnumerable<Type> types, object instance)
        {
            foreach (var @interface in types)
            {
                //@interface.GetMethod("Mapping")?.Invoke(instance, new object[] { this });
                var mapping = @interface?.GetMethod("Mapping");
                mapping?.Invoke(instance, new object[] { this });
                if (!(mapping is null))
                    return true;
            }
            return false;
        }

    }

}
