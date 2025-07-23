using Microsoft.AspNetCore.Mvc;
using SmartRoute.Application.DTOs;
using SmartRoute.Application.Interfaces;
using SmartRoute.Domain.Entities;

namespace SmartRoute.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveryRoutesController : ControllerBase
    {
        private readonly IDeliveryRouteService _service;

        public DeliveryRoutesController(IDeliveryRouteService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult<DeliveryRoute> Create([FromBody] DeliveryRouteDto dto)
        {
            var result = _service.CreateRoute(dto);
            return Ok(result);
        }

    }
}
