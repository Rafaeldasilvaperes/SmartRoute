using SmartRoute.Domain.Entities;


namespace SmartRoute.Application.Common.Interfaces.Persistence
{
    public interface IDeliveryRouteRepository : IRepository<DeliveryRoute>
    {        
        Task<List<DeliveryRoute>> GetDeliveryRoutesByDate(DateTime data);
        Task<List<DeliveryRoute>> GetDeliveryRoutesByOriginIbgeCode(string ibgeCode);


    }
}
