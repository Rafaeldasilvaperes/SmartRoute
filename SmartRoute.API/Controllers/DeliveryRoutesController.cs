using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartRoute.Application.DTOs;
using SmartRoute.Application.Features.Routes.Common;
using SmartRoute.Application.Features.Routes.Queries.GetAllDeliveryRoutes;
using SmartRoute.Application.Interfaces;
using SmartRoute.Domain.Entities;

namespace SmartRoute.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveryRoutesController : ControllerBase
    {
        private readonly IDeliveryRouteService _service;
        private readonly IMediator _mediator;

        public DeliveryRoutesController(IDeliveryRouteService service, IMediator mediator)
        {
            _service = service;
            _mediator = mediator;
        }

        [HttpPost]
        public ActionResult<DeliveryRoute> Create([FromBody] DeliveryRouteDto dto)
        {
            var result = _service.CreateRoute(dto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<DeliveryRouteResult>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllDeliveryRoutesQuery());
            return Ok(result);
        }

    }
}
