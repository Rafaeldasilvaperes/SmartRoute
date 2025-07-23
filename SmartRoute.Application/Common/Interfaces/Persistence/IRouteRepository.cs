using SmartRoute.Domain.Entities;


namespace SmartRoute.Application.Common.Interfaces.Persistence
{
    public interface IRouteRepository : IRepository<Route>
    {
        // Aqui você pode adicionar métodos específicos, ex:
        Task<List<Route>> ObterRotasPorDataAsync(DateTime data);
    }

}
