using Autofac;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Pizza4Ps.PizzaService.Domain.DependencyInjection.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            // Tìm tất cả các type trong assembly
            var types = AssemblyReference.Assembly.GetTypes();
            // Lọc các interface và các lớp thực thi
            var interfaces = types.Where(t => t.IsInterface).ToList();
            var implementations = types.Where(t => t.IsClass && !t.IsAbstract).ToList();

            foreach (var interfaceType in interfaces)
            {
                // Tìm lớp thực thi tương ứng cho từng interface
                var implementationType = implementations.FirstOrDefault(t => t.GetInterfaces().Contains(interfaceType));
                if (implementationType != null)
                {
                    // Kiểm tra constructor của lớp thực thi
                    var constructor = implementationType.GetConstructors().FirstOrDefault();
                    if (constructor != null)
                    {
                        var parameters = constructor.GetParameters();
                        bool canBeResolved = parameters.All(p => p.ParameterType.IsInterface || p.ParameterType.IsClass);

                        // Chỉ đăng ký nếu tất cả các tham số của constructor có thể resolve được
                        if (canBeResolved)
                        {
                            services.AddTransient(interfaceType, implementationType);
                        }
                    }
                }
            }
            return services;
        }
    }
}
