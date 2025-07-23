using Microsoft.EntityFrameworkCore;
using SmartRoute.Application.Common.Interfaces.Persistence;
using SmartRoute.Domain.Entities;

namespace SmartRoute.Infrastructure.Persistence.Repositories
{
    public class RouteRepository : Repository<Route>, IRouteRepository
    {
        public RouteRepository(SmartRouteDbContext context) : base(context)
        {
        }

        public async Task<List<Route>> ObterRotasPorDataAsync(DateTime data)
        {
            return await _dbSet
                .Where(r => r.CreatedAt.Date == data.Date)
                .ToListAsync();
        }
    }
}
