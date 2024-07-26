using Application.UserLogin.Dto;
using Application.UserLogin.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> logger;
        private readonly IMediator mediator;

        public LoginController(IMediator _mediator, ILogger<LoginController> _logger)
        {
            mediator = _mediator;
            logger = _logger;
        }

        [HttpPost("ValidateLogin")]
        public async Task<IActionResult> ValidateLogin([FromBody] LoginDto loginDto)
        {
            try
            {
                var login = new LoginCommand { EmailAddress = loginDto.EmailAddress, Password = loginDto.Password };
                var loginDone = await mediator.Send(login);
                if(loginDone == -1)
                {
                    return NotFound("User Not Found !");
                }
                else if(loginDone == 0)
                {
                    return Unauthorized("Incorrect Password !");
                }
                return Ok(loginDone);
            }

            catch
            {
                return BadRequest("There is an error !");
            }
        }


    }
}
