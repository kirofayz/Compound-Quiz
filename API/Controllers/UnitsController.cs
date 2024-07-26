using Application.Units.Dto;
using Application.Units.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        private readonly ILogger<UnitsController> logger;
        private readonly IMediator mediator;
        public UnitsController(IMediator _mediator, ILogger<UnitsController> _logger)
        {
            mediator = _mediator;
            logger = _logger;
        }

        [HttpGet("GetAllUnit")]
        public async Task<IActionResult> GetAllUnit()
        {
            try
            {
                var unitList = new GetAllUnitQuery();
                List<UnitDto> getUnits = await mediator.Send(unitList);
                return Ok(getUnits);
            }

            catch
            {
                return BadRequest("There is an error !!");
            }
        }
    }
}
