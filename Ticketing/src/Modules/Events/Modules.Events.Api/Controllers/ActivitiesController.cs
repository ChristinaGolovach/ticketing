using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modules.Events.Core.Services;

namespace Modules.Events.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivityService _activityService;
        public ActivitiesController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetActivitiesAsync(CancellationToken cancellationToken = default)
        {
            var result = await _activityService.GetActivitiesAsync(cancellationToken);
            return Ok(result);
        }

        [HttpGet("{activityId}/sections/{sectionId}/seats")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSeatsAsync(Guid activityId, Guid sectionId, 
            CancellationToken cancellationToken = default)
        {
            if (activityId == Guid.Empty || sectionId == Guid.Empty) 
            {
                return BadRequest();
            }

            var result = await _activityService.GetSeatsAsync(activityId, sectionId, cancellationToken);

            return Ok(result);
        }
    }
}
