
namespace SmartRoute.Application.Common.Interfaces.Persistence
{
    public interface IUnitOfWork
    {
        IRouteRepository RouteRepository { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
