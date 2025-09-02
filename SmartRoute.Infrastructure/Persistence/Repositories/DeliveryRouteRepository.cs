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
    }
}
