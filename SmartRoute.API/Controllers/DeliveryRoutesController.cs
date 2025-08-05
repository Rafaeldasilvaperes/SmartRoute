using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartRoute.Application.DTOs;
using SmartRoute.Application.Features.Routes.Commands.CreateDeliveryRoute;
using SmartRoute.Application.Features.Routes.Common;
using SmartRoute.Application.Features.Routes.Queries.GetAllDeliveryRoutes;
using SmartRoute.Application.Features.Routes.Queries.GetOneDeliveryRoute;
using SmartRoute.Application.Interfaces;
using SmartRoute.Domain.Entities;

namespace SmartRoute.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveryRoutesController : ControllerBase
    {        
        private readonly IMediator _mediator;

        public DeliveryRoutesController(IMediator mediator)
        {
            
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<DeliveryRouteResult>>> GetAll()
        {
            try
            {
                List<DeliveryRouteResult> result = await _mediator.Send(new GetAllDeliveryRoutesQuery());
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);   
            }
            
        }

        [HttpPost]
        public async Task<ActionResult<DeliveryRouteResult>> Create([FromBody] DeliveryRouteDto dto)
        {
            try
            {
                Task<DeliveryRoute> result = _mediator.Send(new CreateDeliveryRouteCommand(dto));

                var entityAdded = await _mediator.Send(new GetOneDeliveryRouteCommand(dto));

                return Ok(entityAdded);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);   
            }
            
        }  
    }
}
