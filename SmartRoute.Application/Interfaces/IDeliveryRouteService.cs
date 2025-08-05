using SmartRoute.Application.DTOs;
using SmartRoute.Domain.Entities;

namespace SmartRoute.Application.Interfaces
{
    public interface IDeliveryRouteService
    {
        Task<DeliveryRoute> CreateRoute(DeliveryRouteDto dto);
    }
}
