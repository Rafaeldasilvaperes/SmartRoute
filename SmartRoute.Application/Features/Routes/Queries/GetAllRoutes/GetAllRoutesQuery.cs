using MediatR;
using SmartRoute.Application.Features.Routes.Common;

namespace SmartRoute.Application.Features.Routes.Queries.GetAllRoutes
{
    public record GetAllRoutesQuery : IRequest<List<RouteResult>>;

}
