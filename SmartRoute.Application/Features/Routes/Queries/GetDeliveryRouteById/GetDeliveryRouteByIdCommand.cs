using MediatR;
using SmartRoute.Application.Features.Routes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRoute.Application.Features.Routes.Queries.GetDeliveryRouteById
{
    public record class GetDeliveryRouteByIdCommand (Guid Id) : IRequest<DeliveryRouteResult>;
    
}
