using MediatR;
using SmartRoute.Application.Common.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRoute.Application.Features.Routes.Commands.DeleteDeliveryRoute
{
    public class DeleteDeliveryRouteCommandHandler : IRequestHandler<DeleteDeliveryRouteCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDeliveryRouteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteDeliveryRouteCommand request, CancellationToken cancellationToken)
        {
            var existing = await _unitOfWork.DeliveryRouteRepository.GetByIdAsync(request.Id);

            if (existing == null)
                return false;

            _unitOfWork.DeliveryRouteRepository.Delete(existing);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
