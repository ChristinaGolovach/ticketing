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
        public async Task<ViewPaymentDto> GetAsync(Guid paymentId, CancellationToken cancellationToken = default) 
        {
            throw new NotImplementedException();
        }

        [HttpPost("{paymentId}/complete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CompletePaymentAsync(Guid paymentId, CancellationToken cancellationToken = default)
        {
            await _paymentService.CompletePaymentAsync(paymentId);
            return NoContent();
        }

        [HttpPost("{paymentId}/failed")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FailedPaymentAsync(Guid paymentId, CancellationToken cancellationToken = default)
        {
            await _paymentService.FailedPaymentAsync(paymentId);
            return NoContent();
        }

    }
}
