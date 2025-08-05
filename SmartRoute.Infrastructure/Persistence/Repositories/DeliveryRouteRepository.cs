using Microsoft.EntityFrameworkCore;
using SmartRoute.Application.Common.Interfaces.Persistence;
using SmartRoute.Application.DTOs;
using SmartRoute.Domain.Entities;

namespace SmartRoute.Infrastructure.Persistence.Repositories
{
    public class DeliveryRouteRepository : Repository<DeliveryRoute>, IDeliveryRouteRepository
    {
        public DeliveryRouteRepository(SmartRouteDbContext context) : base(context)
        {
        }

        public async Task<DeliveryRoute> GetDeliveryRoute(DeliveryRouteDto deliveryRoute)
        {
            try
            {
                var entity = await _dbSet
                .Where(route => 
                    route.OriginIbgeCode == deliveryRoute.OriginIbgeCode &&
                    route.Origin == deliveryRoute.Origin &&
                    route.Destination == deliveryRoute.Destination &&
                    route.DestinationIbgeCode == deliveryRoute.DestinationIbgeCode
                ).FirstOrDefaultAsync();

                if (entity == null)
                {
                    return new DeliveryRoute();
                }

                return entity;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<List<DeliveryRoute>> GetDeliveryRoutesByDate(DateTime data)
        {
            try
            {
                return await _dbSet
                .Where(r => r.CreatedAt.Date == data.Date)
                .ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception($"Something went wront while trying to get your Delivery Route! Error Message: {e.Message}");
            }            
        }

        public async Task<List<DeliveryRoute>> GetDeliveryRoutesByOriginIbgeCode(string ibgeCode)
        {
            try
            {
                return await _dbSet
                .Where(route => route.OriginIbgeCode == ibgeCode)
                .ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception($"Something went wront while trying to get your Delivery Route! Error Message: {e.Message}");
            }            
        }

        public async Task<DeliveryRoute> AddDeliveryRoute(DeliveryRoute deliveryRouteItem)
        {
            try
            {
                var teste = await _dbSet.AddAsync(deliveryRouteItem);

                return deliveryRouteItem;
            }
            catch (Exception e)
            {
                throw new Exception($"Something went wront while trying to add new Delivery Route!");
            }
        }
    }
}
