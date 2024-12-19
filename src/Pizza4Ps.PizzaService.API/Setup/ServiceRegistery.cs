using Pizza4Ps.PizzaService.API.DependencyInjection.Extentions;
using Pizza4Ps.PizzaService.Application.DependencyInjection.Extentions;
using Pizza4Ps.PizzaService.Domain.DependencyInjection.Extentions;
using Pizza4Ps.PizzaService.Persistence.DependencyInjection.Extentions;

namespace Pizza4Ps.PizzaService.API.Setup
{
    public static class ServiceRegistery
    {
        public static IServiceCollection ServiceRegisteryMethod(this IServiceCollection services)
        {
            // Configure CORS to allow everything
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });
            // Add HttpContextAccessor
            services.AddHttpContextAccessor();

            // Register Application Layer Services
            RegisterApplicationServices(services);

            // Register Persistence Layer Services
            RegisterPersistenceServices(services);

            // Register Domain Layer Services
            RegisterDomainServices(services);

            // Register API Layer Services
            RegisterApiServices(services);

            // Register Infrastructure Services
            RegisterInfrastructureServices(services);
            return services;
        }

        private static void RegisterApplicationServices(IServiceCollection services)
        {
            services.AddServicesFromAssembly();
            services.AddAutoMapperService();
            services.AddMediatRService();
        }

        private static void RegisterPersistenceServices(IServiceCollection services)
        {
            services.AddInterceptorPersistence();
            services.AddSQLServerPersistence();
            services.AddRepositoryAssembly();
        }
        private static void RegisterDomainServices(IServiceCollection services)
        {
            services.AddDomainServices();
        }
        private static void RegisterApiServices(IServiceCollection services)
        {
            services.AddSwaggerAuthUI();
        }

        private static void RegisterInfrastructureServices(IServiceCollection services)
        {
        }
    }
}
