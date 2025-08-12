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
        
        public async Task<DeliveryRoute?> GetDeliveryRouteAsync(DeliveryRouteDto deliveryRoute)
        {
            return await _dbSet.FirstOrDefaultAsync(route =>
                route.OriginIbgeCode == deliveryRoute.OriginIbgeCode &&
                route.Origin == deliveryRoute.Origin &&
                route.Destination == deliveryRoute.Destination &&
                route.DestinationIbgeCode == deliveryRoute.DestinationIbgeCode
            );
        }

        public async Task<List<DeliveryRoute>> GetDeliveryRoutesByDateAsync(DateTime date)
        {
            try
            {
                return await _dbSet
                    .Where(r => r.CreatedAt.Date == date.Date)
                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(
                    $"Something went wrong while trying to get your Delivery Routes by date ({date:yyyy-MM-dd}). " +
                    $"Error Message: {e.Message}", e
                );
            }
        }

        public async Task<List<DeliveryRoute>> GetDeliveryRoutesByOriginIbgeCodeAsync(string ibgeCodeOrigin)
        {
            try
            {
                return await _dbSet
                    .Where(route => route.OriginIbgeCode == ibgeCodeOrigin)
                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(
                    $"Something went wrong while trying to get your Delivery Routes by Origin IBGE Code ({ibgeCodeOrigin}). " +
                    $"Error Message: {e.Message}", e
                );
            }
        } 
        
        public async Task<List<DeliveryRoute>> GetDeliveryRoutesByDestinationIbgeCodeAsync(string ibgeCodeDestination)
        {
            try
            {
                return await _dbSet
                    .Where(route => route.DestinationIbgeCode == ibgeCodeDestination)
                    .ToListAsync();
            }
            catch (Exception e)
            {

                throw new Exception(
                    $"Something went wrong while trying to get your Delivery Routes by Destination IBGE Code ({ibgeCodeDestination}). " +
                    $"Error Message: {e.Message}", e
                );
            }
        }
    }
}
