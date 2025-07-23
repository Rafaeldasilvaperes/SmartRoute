using Microsoft.Extensions.DependencyInjection;
using SmartRoute.Application.Common.Interfaces.Persistence;
using SmartRoute.Application.Interfaces;
using SmartRoute.Application.Services;
using SmartRoute.Infrastructure.Persistence;
using SmartRoute.Infrastructure.Persistence.Repositories;

namespace SmartRoute.Infrastructure.DependencyInjection;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IRouteRepository, RouteRepository>();        
        services.AddScoped<IDeliveryRouteService, DeliveryRouteService>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Outros serviços (como UnitOfWork, context, etc.) entram aqui depois

        return services;
    }
}