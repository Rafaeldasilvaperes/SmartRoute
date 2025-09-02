using MediatR;
using SmartRoute.Application.Common.Interfaces.Persistence;
using SmartRoute.Application.Features.Routes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRoute.Application.Features.Routes.Queries.GetDeliveryRoutesByDate
{
    public class GetDeliveryRoutesByDateHandler : IRequestHandler<GetDeliveryRoutesByDateCommand, List<DeliveryRouteResult>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDeliveryRoutesByDateHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<DeliveryRouteResult>> Handle(GetDeliveryRoutesByDateCommand request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork.DeliveryRouteRepository.GetDeliveryRoutesByDateAsync(request.Date);

            return list.Select(r => new DeliveryRouteResult(r.Id, r.OriginAddress, r.DestinationAddress, r.CreatedAt))
                       .ToList();
        }
    }
}
