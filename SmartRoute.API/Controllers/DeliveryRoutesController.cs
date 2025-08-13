using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartRoute.Application.DTOs;
using SmartRoute.Application.Features.Routes.Commands.CreateDeliveryRoute;
using SmartRoute.Application.Features.Routes.Commands.DeleteDeliveryRoute;
using SmartRoute.Application.Features.Routes.Commands.PartialUpdateDeliveryRoute;
using SmartRoute.Application.Features.Routes.Commands.UpdateDeliveryRoute;
using SmartRoute.Application.Features.Routes.Common;
using SmartRoute.Application.Features.Routes.Queries.GetAllDeliveryRoutes;
using SmartRoute.Application.Features.Routes.Queries.GetDeliveryRouteByIbgeCode;
using SmartRoute.Application.Features.Routes.Queries.GetDeliveryRouteById;
using SmartRoute.Application.Features.Routes.Queries.GetDeliveryRoutesByDate;
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

        [HttpGet("by-date/{date}")]
        public async Task<ActionResult<List<DeliveryRouteResult>>> GetByDate(DateTime date)
        {
            try
            {
                var result = await _mediator.Send(new GetDeliveryRoutesByDateCommand(date));

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [HttpGet("by-origin/{ibgeCode}")]
        public async Task<ActionResult<List<DeliveryRouteResult>>> GetByOriginIbgeCode(string ibgeCode)
        {
            try
            {
                var result = await _mediator.Send(new GetDeliveryRoutesByOriginIbgeCodeCommand(ibgeCode));

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
        [HttpGet("by-destination/{ibgeCode}")]
        public async Task<ActionResult<List<DeliveryRouteResult>>> GetByDestinationIbgeCode(string ibgeCode)
        {
            try
            {
                var result = await _mediator.Send(new GetDeliveryRoutesByDestinationIbgeCodeCommand(ibgeCode));

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [HttpPost("CreateNewDeliveryRoute")]        
        public async Task<ActionResult<DeliveryRouteResult>> CreateNewDeliveryRoute([FromBody] DeliveryRouteDto dto)
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

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<DeliveryRouteResult>> UpdateDeliveryRoute(Guid id, [FromBody] DeliveryRouteDto dto)
        {
            try
            {
                var updatedDeliveryRoute = await _mediator.Send(new UpdateDeliveryRouteCommand(id, dto));

                return Ok(updatedDeliveryRoute);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch("{id:guid}")]
        public async Task<ActionResult<DeliveryRouteResult>> Patch(Guid id, [FromBody] DeliveryRouteDto dto)
        {
            try
            {
                var result = await _mediator.Send(new PartialUpdateDeliveryRouteCommand(id, dto));

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<bool>> DeleteDeliveryRoute(Guid id)
        {
            try
            {
                bool deleted = await _mediator.Send(new DeleteDeliveryRouteCommand(id));

                if (!deleted)
                    return NotFound($"DeliveryRoute with ID {id} not found.");

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
