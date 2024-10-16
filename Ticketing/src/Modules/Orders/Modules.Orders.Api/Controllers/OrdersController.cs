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

        [HttpPost("{userId}/{orderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> AddSeatAsync(Guid userId, Guid orderId, [FromBody] AddSeatDto seat,
            CancellationToken cancellationToken = default)
        {
            if (userId == Guid.Empty || orderId == Guid.Empty || seat == null)
            {
                return BadRequest();
            }

            var result = await _orderService.AddSeatAsync(userId, orderId, seat, cancellationToken);
            //return Created(result);
            return Ok(result);
        }

        //TODO remove user ID
        [HttpPut("{userId}/{orderId}/book")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> BookSeatsAsync(Guid userId, Guid orderId, CancellationToken cancellationToken = default)
        {
            if (userId == Guid.Empty || orderId == Guid.Empty)
            {
                return BadRequest();
            }
            var result = await _orderService.BookSeatsAsync(userId, orderId, cancellationToken);

            return Ok(result);
        }

        [HttpDelete("{userId}/{orderId}/seats/{activitySeatId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteSeatAsync(Guid userId, Guid orderId, Guid activitySeatId,
            CancellationToken cancellationToken = default)
        {
            if (userId == Guid.Empty || orderId == Guid.Empty || activitySeatId == Guid.Empty)
            {
                return BadRequest();
            }

            throw new NotImplementedException();
        }
    }
}
