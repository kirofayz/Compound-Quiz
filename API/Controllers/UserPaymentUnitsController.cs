using Application.CalculateInstallment;
using Application.UserPaymentUnits.Command;
using Application.UserPaymentUnits.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPaymentUnitsController : ControllerBase
    {
        private readonly ILogger<UserPaymentUnitsController> logger;
        private readonly IMediator mediator;
        public UserPaymentUnitsController(IMediator _mediator , ILogger<UserPaymentUnitsController> _logger)
        {
            logger = _logger;
            mediator = _mediator;
        }

        [HttpPost("CreatePayment")]
        public async Task<IActionResult> CreatePayment([FromBody] PaymentDto payment )
        {
            try
            {
                var paymentRequest = new CreatePaymentCommand { Price = payment.Price 
                    , InstallmentStartDate = payment.InstallmentStartDate , 
                    YearsCount = payment.YearsCount , InstallmentPlanId = payment.InstallmentPlanId , UnitId = payment.UnitId
                    , UserId = payment.UserId };
                var done = await mediator.Send(paymentRequest);
                if(done == -1)
                {
                    return NotFound("Unit Not Found");
                }

                var Installments = new CalculatePaymentCommand
                {
                    InstallmentPlanId = payment.InstallmentPlanId
                ,
                    PaymentID = done,
                    Price = payment.Price,
                    StartDate = payment.InstallmentStartDate,
                    YearsCount = payment.YearsCount
                };
                var calculated = await mediator.Send(Installments);
                if(calculated != null && calculated.Any() )
                {
                    return Ok(calculated);

                }
                else
                {
                    return NotFound("No installments were created");
                }

            }
            catch
            {
                return BadRequest("There is an error !");
            }
        }
    }
}
