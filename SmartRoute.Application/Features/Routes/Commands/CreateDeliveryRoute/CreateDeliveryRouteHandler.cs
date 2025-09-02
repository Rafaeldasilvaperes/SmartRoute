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
                OriginAddress = request.dr.OriginAddress,
                OriginLatitude = request.dr.OriginLatitude,
                OriginLongitude = request.dr.OriginLongitude,
                DestinationAddress = request.dr.DestinationAddress,
                DestinationLatitude = request.dr.DestinationLatitude,
                DestinationLongitude = request.dr.DestinationLongitude,
                CreatedAt = request.dr.CreatedAt

            };          

            await _unitOfWork.DeliveryRouteRepository.AddAsync(entity);            
            await _unitOfWork.SaveChangesAsync();


            return new DeliveryRouteResult(
                            entity.Id,
                            entity.OriginAddress,                            
                            entity.DestinationAddress,                           
                            entity.CreatedAt);
        }
    }
}
