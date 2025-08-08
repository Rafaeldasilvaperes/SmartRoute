using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartRoute.Application.DTOs;
using SmartRoute.Application.Features.Routes.Commands.CreateDeliveryRoute;
using SmartRoute.Application.Features.Routes.Common;
using SmartRoute.Application.Features.Routes.Queries.GetAllDeliveryRoutes;
using SmartRoute.Application.Features.Routes.Queries.GetDeliveryRouteById;
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

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<DeliveryRouteResult>> GetById(Guid id)
        {
            try
            {
                var result = await _mediator.Send(new GetDeliveryRouteByIdCommand(id));
                return Ok(result);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]        
        public async Task<ActionResult<DeliveryRouteResult>> Create([FromBody] DeliveryRouteDto dto)
        {
            try
            {
                var createdEntity = await _mediator.Send(new CreateDeliveryRouteCommand(dto));                               

                return CreatedAtAction(nameof(GetAll), new { id = createdEntity.Id }, createdEntity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
