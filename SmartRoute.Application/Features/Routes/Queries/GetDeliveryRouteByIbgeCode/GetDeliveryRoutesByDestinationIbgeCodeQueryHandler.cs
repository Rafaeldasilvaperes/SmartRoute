using MediatR;
using SmartRoute.Application.Common.Interfaces.Persistence;
using SmartRoute.Application.Features.Routes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRoute.Application.Features.Routes.Queries.GetDeliveryRouteByIbgeCode
{
    public class GetDeliveryRoutesByDestinationIbgeCodeQueryHandler
    : IRequestHandler<GetDeliveryRoutesByDestinationIbgeCodeCommand, List<DeliveryRouteResult>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDeliveryRoutesByDestinationIbgeCodeQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<DeliveryRouteResult>> Handle(GetDeliveryRoutesByDestinationIbgeCodeCommand request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork.DeliveryRouteRepository.GetDeliveryRoutesByDestinationIbgeCodeAsync(request.IbgeCodeDestination);

            return list.Select(r => new DeliveryRouteResult(r.Id, r.Origin, r.OriginIbgeCode, r.Destination, r.DestinationIbgeCode))
                       .ToList();
        }
    }
}
