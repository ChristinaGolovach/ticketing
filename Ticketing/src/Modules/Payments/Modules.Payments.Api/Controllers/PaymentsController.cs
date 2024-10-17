using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modules.Payments.Core.Models;
using Modules.Payments.Core.Services;

namespace Modules.Payments.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet("{paymentId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ViewPaymentDto>> GetAsync(Guid paymentId, CancellationToken cancellationToken = default) 
        {
            if (paymentId == Guid.Empty)
            {
                return BadRequest();
            }

            var result = await _paymentService.GetPaymentAsync(paymentId, cancellationToken);
            return Ok(result);
        }

        [HttpPost("{paymentId}/complete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CompletePaymentAsync(Guid paymentId, CancellationToken cancellationToken = default)
        {
            if (paymentId == Guid.Empty)
            {
                return BadRequest();
            }

            await _paymentService.CompletePaymentAsync(paymentId, cancellationToken);
            return NoContent();
        }

        [HttpPost("{paymentId}/failed")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FailedPaymentAsync(Guid paymentId, CancellationToken cancellationToken = default)
        {
            if (paymentId == Guid.Empty)
            {
                return BadRequest();
            }

            await _paymentService.FailedPaymentAsync(paymentId, cancellationToken);
            return NoContent();
        }
    }
}
