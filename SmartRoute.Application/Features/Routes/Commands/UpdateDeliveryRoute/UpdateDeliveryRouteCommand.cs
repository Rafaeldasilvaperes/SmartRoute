using MediatR;
using SmartRoute.Application.DTOs;
using SmartRoute.Application.Features.Routes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRoute.Application.Features.Routes.Commands.UpdateDeliveryRoute
{
    public record UpdateDeliveryRouteCommand(Guid Id, DeliveryRouteDto dto) : IRequest<DeliveryRouteResult>;

}
