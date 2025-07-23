using SmartRoute.Application.Common.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRoute.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SmartRouteDbContext _context;
        public IRouteRepository RouteRepository { get; }

        public UnitOfWork(SmartRouteDbContext context, IRouteRepository routeRepository)
        {
            _context = context;
            RouteRepository = routeRepository;
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

    }
}
