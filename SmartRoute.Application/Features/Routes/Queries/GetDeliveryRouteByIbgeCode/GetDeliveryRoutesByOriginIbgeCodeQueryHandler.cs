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
    public class GetDeliveryRoutesByOriginIbgeCodeQueryHandler
        : IRequestHandler<GetDeliveryRoutesByOriginIbgeCodeCommand, List<DeliveryRouteResult>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDeliveryRoutesByOriginIbgeCodeQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<DeliveryRouteResult>> Handle(GetDeliveryRoutesByOriginIbgeCodeCommand request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork.DeliveryRouteRepository.GetDeliveryRoutesByOriginIbgeCodeAsync(request.IbgeCodeOrigin);

            return list.Select(r => new DeliveryRouteResult(r.Id, r.Origin, r.OriginIbgeCode, r.Destination, r.DestinationIbgeCode))
                       .ToList();
        }
    }
}
