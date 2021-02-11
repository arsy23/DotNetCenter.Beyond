namespace DotNetCenter.Beyond.Mapping
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    public class BaseProfile : Profile
    {
        #region Constructors
        public BaseProfile()
        { }
        public BaseProfile(Assembly executingAssembly) 
            => ApplyMappingsFromAssembly(executingAssembly);
        #endregion
        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            InvokeIMapFrom(assembly);
            InvokeIMapTo(assembly);
        }
        #region Invoke Methods
        private bool InvokeIMapTo(Assembly assembly)
        {
            var isAllInvoked  = true;
            var exportedTypes = GetIMapToExportedTypes(assembly);
            if (exportedTypes is null)
                isAllInvoked = false;
            else
                foreach (var type in exportedTypes)
                    isAllInvoked &= InvokeMappingMethodImplementationForIMapTo(type);

            return isAllInvoked;
        }
        private bool InvokeIMapFrom(Assembly assembly)
        {
            var isAllInvoked = true;
            var exportedTypes = GetIMapFromExportedTypes(assembly);
            if (exportedTypes is null)
                return false;
            else
                foreach (var type in exportedTypes)
                    isAllInvoked &= InvokeMappingMethodForIMapFrom(type);
            return isAllInvoked;
        }
        private bool InvokeMappingMethodForIMapFrom(Type type)
        {
            var instance = Activator.CreateInstance(type);
            bool isAllInvoked;
            if (instance is null)
                return false;
            if (TryInvokeClassMethodImplementation(type, instance))
                return true;
            else 
                isAllInvoked = TryInvokeInterfacMethodImplementation(GetMapFromInterfaces(type), instance);

            return isAllInvoked;
        }
        private bool InvokeMappingMethodImplementationForIMapTo(Type type)
        {
            var instance = Activator.CreateInstance(type);
            if (instance == null)
                return false;
            if (!TryInvokeClassMethodImplementation(type, instance))
                return TryInvokeInterfacMethodImplementation(GetMapToInterfaces(type), instance);
            return true;
        }
        #endregion
        #region TryToInvoke Methods
        private bool TryInvokeClassMethodImplementation(Type type, object instance)
        {
            var methodInfo = type?.GetMethod("Mapping");
            if (methodInfo is null)
                return false;
            methodInfo?.Invoke(instance, new object[] { this });
            return true;
        }
        private bool TryInvokeInterfacMethodImplementation(IEnumerable<Type> types, object instance)
        {
            foreach (var @interface in types)
            {
                var mapping = @interface?.GetMethod("Mapping");
                if (mapping is null)
                    continue;
                else
                {
                    mapping?.Invoke(instance, new object[] { this });
                    return true;
                }
            }
            return false;
        }
        #endregion
        #region GetMap Interfaces
        private static IEnumerable<Type> GetMapToInterfaces(Type type)
            => type
            .GetInterfaces()
            .Where(o => 
            o.IsGenericType 
            && o.GetGenericTypeDefinition() == typeof(IMapTo<>));
        private static List<Type> GetMapFromInterfaces(Type type) 
            => type
            .GetInterfaces()
            .Where(o => 
            o.GetGenericTypeDefinition() == typeof(IMapFrom<>) 
            && o.IsGenericType)
            .ToList();
        #endregion
        #region GetMap ExportedTypes
        private static List<Type> GetIMapFromExportedTypes(Assembly assembly) 
            => assembly
            .GetExportedTypes()
            .Where(t => 
            t.GetInterfaces()
            .Any(i => 
            i.IsGenericType 
            && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
            .ToList();
        private static List<Type> GetIMapToExportedTypes(Assembly assembly) 
            => assembly
            .GetExportedTypes()
            .Where(t => 
            t.GetInterfaces()
            .Any(i => i.IsGenericType 
            && i.GetGenericTypeDefinition() == typeof(IMapTo<>)))
            .ToList();
        #endregion
    }
}
