using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modules.Orders.Core.Models;
using Modules.Orders.Core.Services;

namespace Modules.Orders.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{userId}/{orderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOrderAsync(Guid userId, Guid orderId, CancellationToken cancellationToken = default)
        {
            if (userId == Guid.Empty || orderId == Guid.Empty)
            {
                return BadRequest();
            }

            var result = await _orderService.GetOrderAsync(userId, orderId, cancellationToken);

            return Ok(result);
        }

        [HttpPost("{orderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> AddSeatAsync(Guid orderId, [FromBody] AddSeatDto seat,
            CancellationToken cancellationToken = default)
        {
            if (orderId == Guid.Empty || seat == null)
            {
                return BadRequest();
            }

            var result = await _orderService.AddSeatAsync(orderId, seat, cancellationToken);

            //return Created(link, result);
            return Ok(result);
        }

        [HttpPut("{orderId}/book")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> BookSeatsAsync(Guid orderId, CancellationToken cancellationToken = default)
        {
            if (orderId == Guid.Empty)
            {
                return BadRequest();
            }
            var result = await _orderService.BookSeatsAsync(orderId, cancellationToken);

            return Ok(result);
        }

        [HttpDelete("{orderId}/seats/{activitySeatId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteSeatAsync(Guid orderId, Guid activitySeatId,
            CancellationToken cancellationToken = default)
        {
            if (orderId == Guid.Empty || activitySeatId == Guid.Empty)
            {
                return BadRequest();
            }

            await _orderService.DeleteSeatAsync(orderId, activitySeatId, cancellationToken);

            return NoContent();
        }
    }
}
