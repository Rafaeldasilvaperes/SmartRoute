using MediatR;
using SmartRoute.Application.Features.Routes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRoute.Application.Features.Routes.Queries.GetDeliveryRouteByIbgeCode
{
     public record GetDeliveryRoutesByDestinationIbgeCodeCommand(string IbgeCodeDestination) : IRequest<List<DeliveryRouteResult>>;

}
