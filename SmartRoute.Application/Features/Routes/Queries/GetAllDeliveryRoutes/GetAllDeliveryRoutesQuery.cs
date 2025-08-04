using MediatR;
using SmartRoute.Application.Features.Routes.Common;

namespace SmartRoute.Application.Features.Routes.Queries.GetAllDeliveryRoutes
{
    public record GetAllDeliveryRoutesQuery : IRequest<List<DeliveryRouteResult>>;

}
