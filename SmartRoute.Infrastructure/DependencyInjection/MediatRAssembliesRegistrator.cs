using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SmartRoute.Application.Features.Routes.Queries.GetAllDeliveryRoutes;


namespace SmartRoute.Infrastructure.DependencyInjection
{
    public static class MediatRAssembliesRegistrator
    {
        public static IServiceCollection AddMediatRServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetAllDeliveryRoutesQueryHandler>());

            return services;
        }
    }
}
