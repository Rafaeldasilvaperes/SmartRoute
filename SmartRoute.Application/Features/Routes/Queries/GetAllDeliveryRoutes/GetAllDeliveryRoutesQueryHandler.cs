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

        public async Task<List<DeliveryRouteResult>> Handle(GetAllDeliveryRoutesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<DeliveryRoute> routes = await _unitOfWork.DeliveryRouteRepository.GetAllAsync(cancellationToken);

                return routes.Select(r => new DeliveryRouteResult(r.Id, r.Origin, r.OriginIbgeCode, r.Destination, r.DestinationIbgeCode)).ToList();
            }
            catch (Exception e)
            {
                throw new Exception($"Something went wrong while trying to get your Delivery Routes. Try again later!");
            }
            
        }        
    }
}
