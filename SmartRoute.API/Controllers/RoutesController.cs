using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartRoute.Application.Features.Routes.Common;
using SmartRoute.Application.Features.Routes.Queries.GetAllRoutes;

namespace SmartRoute.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoutesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoutesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<RouteResult>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllRoutesQuery());
            return Ok(result);
        }
    }
}
