using Autofac;
using Microsoft.Extensions.DependencyInjection;
using Pizza4Ps.CustomerService.Domain.Abstractions.Services.ServiceBase;
using System.Reflection;

namespace Pizza4Ps.CustomerService.Domain.DependencyInjection.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            // Đăng ký tất cả các lớp kế thừa IDomainService hoặc DomainService
            services.Scan(scan => scan
                .FromAssemblies(Assembly.GetExecutingAssembly()) // Hoặc chỉ định Assembly cụ thể
                .AddClasses(classes => classes.AssignableTo<IDomainService>()) // Tìm các class kế thừa IDomainService
                .AsImplementedInterfaces() // Đăng ký dưới dạng interface đã implement
                .WithScopedLifetime()); // Hoặc .WithSingletonLifetime() hoặc .WithTransientLifetime()
            return services;
        }
    }
}
