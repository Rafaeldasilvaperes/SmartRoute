using MediatR;
using SmartRoute.Application.Common.Interfaces.Persistence;
using SmartRoute.Application.Features.Routes.Common;
using SmartRoute.Domain.Entities;


namespace SmartRoute.Application.Features.Routes.Commands.CreateDeliveryRoute
{
    public class CreateDeliveryRouteHandler : IRequestHandler<CreateDeliveryRouteCommand, DeliveryRouteResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateDeliveryRouteHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DeliveryRouteResult> Handle(CreateDeliveryRouteCommand request, CancellationToken cancellation)
        {
            var entity = new DeliveryRoute
            {
                Origin = request.dto.Origin,
                OriginIbgeCode = request.dto.OriginIbgeCode,
                Destination = request.dto.Destination,
                DestinationIbgeCode = request.dto.DestinationIbgeCode
            };

            await _unitOfWork.DeliveryRouteRepository.AddAsync(entity);            
            await _unitOfWork.SaveChangesAsync();


            return new DeliveryRouteResult(
                            entity.Id,
                            entity.Origin,
                            entity.OriginIbgeCode,
                            entity.Destination,
                            entity.DestinationIbgeCode);
        }
    }
}
