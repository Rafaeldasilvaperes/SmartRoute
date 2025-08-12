using MediatR;
using SmartRoute.Application.Common.Interfaces.Persistence;
using SmartRoute.Application.Features.Routes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRoute.Application.Features.Routes.Commands.UpdateDeliveryRoute
{
    public class UpdateDeliveryRouteCommandHandler : IRequestHandler<UpdateDeliveryRouteCommand, DeliveryRouteResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDeliveryRouteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DeliveryRouteResult> Handle(UpdateDeliveryRouteCommand request, CancellationToken cancellationToken)
        {
            var existing = await _unitOfWork.DeliveryRouteRepository.GetByIdAsync(request.Id);

            if (existing == null)
                throw new Exception($"DeliveryRoute with ID {request.Id} not found.");

            existing.Origin = request.dto.Origin;
            existing.OriginIbgeCode = request.dto.OriginIbgeCode;
            existing.Destination = request.dto.Destination;
            existing.DestinationIbgeCode = request.dto.DestinationIbgeCode;

            _unitOfWork.DeliveryRouteRepository.Update(existing);

            await _unitOfWork.SaveChangesAsync();

            return new DeliveryRouteResult(
                existing.Id,
                existing.Origin,
                existing.OriginIbgeCode,
                existing.Destination,
                existing.DestinationIbgeCode
            );
        }
    }
}
