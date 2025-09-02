using MediatR;
using SmartRoute.Application.Common.Interfaces.Persistence;
using SmartRoute.Application.Features.Routes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SmartRoute.Application.Features.Routes.Commands.PartialUpdateDeliveryRoute
{
    public class PartialUpdateDeliveryRouteCommandHandler : IRequestHandler<PartialUpdateDeliveryRouteCommand, DeliveryRouteResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public PartialUpdateDeliveryRouteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DeliveryRouteResult> Handle(PartialUpdateDeliveryRouteCommand request, CancellationToken cancellationToken)
        {
            var existing = await _unitOfWork.DeliveryRouteRepository.GetByIdAsync(request.Id);

            if (existing == null)
                throw new Exception($"DeliveryRoute with ID {request.Id} not found.");
            
            var dtoProps = request.dto.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var dtoProp in dtoProps)
            {
                var newValue = dtoProp.GetValue(request.dto);
                
                if (newValue == null) continue;
                if (newValue is string str && string.IsNullOrWhiteSpace(str)) continue;
                
                var entityProp = existing.GetType().GetProperty(dtoProp.Name, BindingFlags.Public | BindingFlags.Instance);
                if (entityProp != null && entityProp.CanWrite)
                {
                    entityProp.SetValue(existing, newValue);
                }
            }

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
