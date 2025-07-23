using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SmartRoute.Application.Features.Routes.Queries.GetAllRoutes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRoute.Infrastructure.DependencyInjection
{
    public static class MediatRAssembliesRegistrator
    {
        public static IServiceCollection AddMediatRServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetAllRoutesQueryHandler>());

            return services;
        }
    }
}
