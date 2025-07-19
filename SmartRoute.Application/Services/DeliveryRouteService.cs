using SmartRoute.Application.DTOs;
using SmartRoute.Application.Interfaces;
using SmartRoute.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRoute.Application.Services
{
    public class DeliveryRouteService : IDeliveryRouteService
    {
        public DeliveryRoute CreateRoute(DeliveryRouteDto dto)
        {
            return new DeliveryRoute
            {
                Origin = dto.Origin,
                Destination = dto.Destination
            };
        }
    }
}
