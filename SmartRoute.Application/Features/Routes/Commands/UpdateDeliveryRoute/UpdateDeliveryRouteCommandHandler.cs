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

            existing.OriginAddress = request.dr.OriginAddress;
            existing.OriginLatitude = request.dr.OriginLatitude;
            existing.OriginLongitude = request.dr.OriginLongitude;
            existing.DestinationAddress = request.dr.DestinationAddress;
            existing.DestinationLatitude = request.dr.DestinationLatitude;
            existing.DestinationLongitude = request.dr.DestinationLongitude;
            existing.CreatedAt = request.dr.CreatedAt;

            _unitOfWork.DeliveryRouteRepository.Update(existing);

            await _unitOfWork.SaveChangesAsync();

            return new DeliveryRouteResult(
                existing.Id,
                existing.OriginAddress,
                existing.DestinationAddress,
                existing.CreatedAt                
            );
        }
    }
}
