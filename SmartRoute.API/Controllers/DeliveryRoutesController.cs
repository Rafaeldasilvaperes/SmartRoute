using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartRoute.Application.DTOs;
using SmartRoute.Application.Features.Routes.Commands.CreateDeliveryRoute;
using SmartRoute.Application.Features.Routes.Commands.DeleteDeliveryRoute;
using SmartRoute.Application.Features.Routes.Commands.PartialUpdateDeliveryRoute;
using SmartRoute.Application.Features.Routes.Commands.UpdateDeliveryRoute;
using SmartRoute.Application.Features.Routes.Common;
using SmartRoute.Application.Features.Routes.Queries.GetAllDeliveryRoutes;
using SmartRoute.Application.Features.Routes.Queries.GetDeliveryRouteById;
using SmartRoute.Application.Features.Routes.Queries.GetDeliveryRoutesByDate;
using SmartRoute.Domain.Entities;

namespace SmartRoute.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveryRoutesController : ControllerBase
    {        
        private readonly IMediator _mediator;
        private readonly ILogger<DeliveryRoutesController> _logger;

        public DeliveryRoutesController(IMediator mediator, ILogger<DeliveryRoutesController> logger)
        {
            
            _mediator = mediator;
            _logger = logger;
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
                _logger.LogError(e, "Error at GetAll DeliveryRoutes");
                return BadRequest("Something went wrong while trying to GetAll Delivery Routes!");   
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
                _logger.LogError(e, "Error at GetById DeliveryRoutes");
                return NotFound("Something went wrong while trying to Get Delivery Route by Id");
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
                _logger.LogError(e, "Error at GetByDate DeliveryRoutes");
                return BadRequest("Something went wrong while trying to Get Delivery Routes by Date");
            }
            
        }        

        [HttpPost("CreateNewDeliveryRoute")]        
        public async Task<ActionResult<DeliveryRouteResult>> CreateNewDeliveryRoute([FromBody] DeliveryRoute deliveryRoute)
        {
            try
            {
                var createdEntity = await _mediator.Send(new CreateDeliveryRouteCommand(deliveryRoute));                               

                return CreatedAtAction(nameof(GetAll), new { id = createdEntity.Id }, createdEntity);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error at CreateNewDeliveryRoute DeliveryRoutes");
                return NotFound("Something went wrong while trying to Create New Delivery Route");
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<DeliveryRouteResult>> UpdateDeliveryRoute(Guid id, [FromBody] DeliveryRoute deliveryRoute)
        {
            try
            {
                var updatedDeliveryRoute = await _mediator.Send(new UpdateDeliveryRouteCommand(id, deliveryRoute));

                return Ok(updatedDeliveryRoute);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error at UpdateDeliveryRoute DeliveryRoutes");
                return NotFound("Something went wrong while trying to Update the Delivery Route");
            }
        }

        [HttpPatch("{id:guid}")]
        public async Task<ActionResult<DeliveryRouteResult>> PatchDeliveryRoute(Guid id, [FromBody] DeliveryRouteDto dto)
        {
            try
            {
                var result = await _mediator.Send(new PartialUpdateDeliveryRouteCommand(id, dto));

                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error at PatchDeliveryRoute DeliveryRoutes");
                return NotFound("Something went wrong while trying to Update Partially the Delivery Route");
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
                _logger.LogError(e, "Error at DeleteDeliveryRoute DeliveryRoutes");
                return NotFound("Something went wrong while trying to Delete the Delivery Route");
            }
        }
    }
}
