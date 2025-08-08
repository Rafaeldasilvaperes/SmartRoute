using MediatR;
using SmartRoute.Application.Common.Interfaces.Persistence;
using SmartRoute.Application.Features.Routes.Common;
using SmartRoute.Application.Features.Routes.Queries.GetDeliveryRouteById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRoute.Application.Features.Routes.Queries.GetByIdDeliveryRoute
{
    public class GetDeliveryRouteByIdHandler : IRequestHandler<GetDeliveryRouteByIdCommand, DeliveryRouteResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDeliveryRouteByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DeliveryRouteResult> Handle(GetDeliveryRouteByIdCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.DeliveryRouteRepository.GetByIdAsync(request.Id);

            if (entity is null)
                throw new KeyNotFoundException($"Delivery Route with ID {request.Id} not found.");

            return new DeliveryRouteResult(
                entity.Id,
                entity.Origin,
                entity.OriginIbgeCode,
                entity.Destination,
                entity.DestinationIbgeCode
            );
        }
    }
}
