using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Pizza4Ps.PizzaService.Application.DependencyInjection.Extentions
{
    public static class ServiceCollectionExtention
    {
        public static IServiceCollection AddServicesFromAssembly(this IServiceCollection services)
        {
            Assembly assembly = AssemblyReference.Assembly;
            // Get all types from the assembly
            var types = assembly.GetTypes();

            // Iterate through all types in the assembly
            foreach (var type in types)
            {
                // Get the interfaces implemented by this type
                var interfaces = type.GetInterfaces();

                // Register services that follow the convention (e.g., classes implementing IService)
                foreach (var @interface in interfaces)
                {
                    // If the type is a class, is not abstract, and implements an interface, register it.
                    if (type.IsClass && !type.IsAbstract)
                    {
                        services.AddTransient(@interface, type); // Add to DI container (Scoped as an example)
                    }
                }
            }

            return services;
        }
        public static void AddAutoMapperService(this IServiceCollection services)
        {
            services.AddAutoMapper(AssemblyReference.Assembly);
        }
        public static void AddMediatRService(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(AssemblyReference.Assembly));
        }
    }
}
