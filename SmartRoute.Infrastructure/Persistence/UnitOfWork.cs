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
        private  SmartRouteDbContext _context;       
        public IDeliveryRouteRepository DeliveryRouteRepository { get; }

        public UnitOfWork(SmartRouteDbContext context, IDeliveryRouteRepository deliveryRouteRepository)
        {
            _context = context;           
            DeliveryRouteRepository = deliveryRouteRepository;
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

    }
}
