
namespace SmartRoute.Application.Common.Interfaces.Persistence
{
    public interface IUnitOfWork
    {
        IDeliveryRouteRepository DeliveryRouteRepository { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
