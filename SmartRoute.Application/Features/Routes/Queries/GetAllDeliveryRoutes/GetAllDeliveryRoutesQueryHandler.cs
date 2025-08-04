using MediatR;
using SmartRoute.Application.Common.Interfaces.Persistence;
using SmartRoute.Application.Features.Routes.Common;
using SmartRoute.Domain.Entities;


namespace SmartRoute.Application.Features.Routes.Queries.GetAllDeliveryRoutes
{
    public class GetAllDeliveryRoutesQueryHandler : IRequestHandler<GetAllDeliveryRoutesQuery, List<DeliveryRouteResult>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllDeliveryRoutesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //public async Task<List<RouteResult>> Handle(GetAllRoutesQuery request, CancellationToken cancellationToken)
        //{
        //    IEnumerable<Route> routes = await _unitOfWork.RouteRepository.GetAllAsync(cancellationToken);
        //    return routes.Select(r => new RouteResult(r.Id, r.Origin, r.OriginIbgeCode, r.Destination, r.DestinationIbgeCode)).ToList();
        //}

        public async Task<List<DeliveryRouteResult>> Handle(GetAllDeliveryRoutesQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<DeliveryRoute> routes = await _unitOfWork.DeliveryRouteRepository.GetAllAsync(cancellationToken);
            return routes.Select(r => new DeliveryRouteResult(r.Id, r.Origin, r.OriginIbgeCode, r.Destination, r.DestinationIbgeCode)).ToList();
        }


    }
}
