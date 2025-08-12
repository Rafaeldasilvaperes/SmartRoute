using SmartRoute.Application.DTOs;
using SmartRoute.Domain.Entities;


namespace SmartRoute.Application.Common.Interfaces.Persistence
{
    public interface IDeliveryRouteRepository : IRepository<DeliveryRoute>
    {      
        Task<DeliveryRoute?> GetDeliveryRouteAsync(DeliveryRouteDto deliveryRoute);
        Task<List<DeliveryRoute>> GetDeliveryRoutesByDateAsync(DateTime data);
        Task<List<DeliveryRoute>> GetDeliveryRoutesByOriginIbgeCodeAsync(string ibgeCodeOrigin);
        Task<List<DeliveryRoute>> GetDeliveryRoutesByDestinationIbgeCodeAsync(string ibgeCodeDestination);
    }
}
