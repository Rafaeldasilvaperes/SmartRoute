using MediatR;
using SmartRoute.Application.Common.Interfaces.Persistence;
using SmartRoute.Application.Features.Routes.Common;
using SmartRoute.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRoute.Application.Features.Routes.Queries.GetAllRoutes
{
    public class GetAllRoutesQueryHandler : IRequestHandler<GetAllRoutesQuery, List<RouteResult>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllRoutesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<RouteResult>> Handle(GetAllRoutesQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Route> routes = await _unitOfWork.RouteRepository.GetAllAsync(cancellationToken);
            return routes.Select(r => new RouteResult(r.Id, r.Origin, r.Destination)).ToList();
        }
    }
}
