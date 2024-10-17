using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modules.Events.Core.Models;
using Modules.Events.Core.Services;

namespace Modules.Events.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenuesController : ControllerBase
    {
        private readonly IVenueService _venueService;
        public VenuesController(IVenueService venueService)
        {
            _venueService = venueService;
        }

        [HttpGet]
        //[SwaggerOperation("Get all venues.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IList<ViewVenueDto>>> GetVenuesAsync(CancellationToken cancellationToken = default)
        {
            var result = await _venueService.GetVenuesAsync(cancellationToken);

            return Ok(result);
        }

        [HttpGet("{venueId}/sections")]
        //[SwaggerOperation("Get all sections for a venue.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IList<ViewSectionDto>>> GetSectionsAsync(Guid venueId,
            CancellationToken cancellationToken = default)
        {
            if (venueId == Guid.Empty) 
            {
                return BadRequest();
            }

            var result = await _venueService.GetSectionsAsync(venueId, cancellationToken);

            return Ok(result);
        }
    }
}
