using SmartRoute.Application.DTOs;
using SmartRoute.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRoute.Application.Interfaces
{
    public interface IDeliveryRouteService
    {
        DeliveryRoute CreateRoute(DeliveryRouteDto dto);
    }
}
