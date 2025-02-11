using System.Reflection;
using AutoMapper;

namespace PawsPlus.Application.Common.Mapping;

public class MappingProfile : Profile
{

    public MappingProfile()
        => this.ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());

    public void ApplyMappingsFromAssembly(Assembly assembly)
    {
        var types = assembly.GetExportedTypes()
            .Where(t => t.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
            .ToList();
    
        const string MethodName = "Mapping";
        
        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);
            var methodInfo = type.GetMethod(MethodName)
                             ?? type.GetInterface("IMapFrom`1")?.GetMethod(MethodName);

            methodInfo?.Invoke(instance, new object[] { this });
        }
    } 
}