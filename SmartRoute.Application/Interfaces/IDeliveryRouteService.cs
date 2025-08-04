using SmartRoute.Application.DTOs;
using SmartRoute.Domain.Entities;

namespace SmartRoute.Application.Interfaces
{
    public interface IDeliveryRouteService
    {
        DeliveryRoute CreateRoute(DeliveryRouteDto dto);
    }
}
