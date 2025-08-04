using Microsoft.EntityFrameworkCore;
using SmartRoute.Application.Common.Interfaces.Persistence;
using SmartRoute.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRoute.Infrastructure.Persistence.Repositories
{
    public class DeliveryRouteRepository : Repository<DeliveryRoute>, IDeliveryRouteRepository
    {
        public DeliveryRouteRepository(SmartRouteDbContext context) : base(context)
        {
        }

        public async Task<List<DeliveryRoute>> GetDeliveryRoutesByDate(DateTime data)
        {
            return await _dbSet
                .Where(r => r.CreatedAt.Date == data.Date)
                .ToListAsync();
        }

        public async Task<List<DeliveryRoute>> GetDeliveryRoutesByOriginIbgeCode(string ibgeCode)
        {
            return await _dbSet
                .Where(route => route.OriginIbgeCode == ibgeCode)
                .ToListAsync();
        }
    }
}
