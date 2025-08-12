using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRoute.Application.Features.Routes.Commands.DeleteDeliveryRoute
{
    public record DeleteDeliveryRouteCommand(Guid Id) : IRequest<bool>;

}
