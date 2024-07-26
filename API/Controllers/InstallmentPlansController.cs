using Application.InstallmentPlans.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstallmentPlansController : ControllerBase
    {
        private readonly ILogger<InstallmentPlansController> logger;
        private readonly IMediator mediator;
        public InstallmentPlansController(IMediator _mediator, ILogger<InstallmentPlansController> _logger)
        {
            mediator = _mediator;
            logger = _logger;
        }

        [HttpGet("GetAllPlans")]
        public async Task<IActionResult> GetAllPlans()
        {
            try
            {
                var planList = new GetAllInstallmentPlansQuery();
                var planListDto = await mediator.Send(planList);
                return Ok(planListDto);
            }
            catch
            {
                return BadRequest("There is an error !!");
            }
        }
    }
}
