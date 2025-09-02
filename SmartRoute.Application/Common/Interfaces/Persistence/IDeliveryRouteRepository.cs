using SmartRoute.Application.DTOs;
using SmartRoute.Domain.Entities;


namespace SmartRoute.Application.Common.Interfaces.Persistence
{
    public interface IDeliveryRouteRepository : IRepository<DeliveryRoute>
    {      
        Task<List<DeliveryRoute>> GetDeliveryRoutesByDateAsync(DateTime data);    
    }
}
