using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using SmartRoute.Application.Common.Interfaces.Persistence;
using SmartRoute.Application.DTOs;
using SmartRoute.Application.Features.Routes.Commands.CreateDeliveryRoute;
using SmartRoute.Infrastructure.Persistence;
using SmartRoute.Infrastructure.Persistence.Repositories;

namespace SmartRoute.Infrastructure.DependencyInjection;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {               
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IDeliveryRouteRepository, DeliveryRouteRepository>();
       
        services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

        services.AddValidatorsFromAssemblyContaining<DeliveryRouteDtoValidator>();


        //services.AddControllers()
        //.AddFluentValidation(fv =>
        //{
        //    fv.RegisterValidatorsFromAssemblyContaining<CreateDeliveryRouteCommandValidator>();
        //});

        return services;
    }
}