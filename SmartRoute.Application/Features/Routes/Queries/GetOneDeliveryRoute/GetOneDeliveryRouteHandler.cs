using MediatR;
using SmartRoute.Application.Common.Interfaces.Persistence;
using SmartRoute.Application.Features.Routes.Common;
using SmartRoute.Domain.Entities;


namespace SmartRoute.Application.Features.Routes.Queries.GetOneDeliveryRoute
{
    public class GetOneDeliveryRouteHandler : IRequestHandler<GetOneDeliveryRouteCommand, DeliveryRouteResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetOneDeliveryRouteHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DeliveryRouteResult> Handle(GetOneDeliveryRouteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var routes = await _unitOfWork.DeliveryRouteRepository.GetDeliveryRouteAsync(request.dto);

                var teste = new DeliveryRouteResult(routes.Id, routes.Origin, routes.OriginIbgeCode, routes.Destination, routes.DestinationIbgeCode);

                return teste;
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
