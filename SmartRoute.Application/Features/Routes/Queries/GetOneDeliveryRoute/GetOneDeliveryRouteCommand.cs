using MediatR;
using SmartRoute.Application.DTOs;
using SmartRoute.Application.Features.Routes.Common;

namespace SmartRoute.Application.Features.Routes.Queries.GetOneDeliveryRoute
{
    public record GetOneDeliveryRouteCommand(DeliveryRouteDto dto) : IRequest<DeliveryRouteResult>;   
}
