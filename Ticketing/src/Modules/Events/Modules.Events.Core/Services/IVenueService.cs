using Modules.Events.Core.Models;

namespace Modules.Events.Core.Services
{
    public interface IVenueService
    {
        Task<IList<ViewVenueDto>> GetVenuesAsync(CancellationToken cancellationToken = default);
        Task<IList<ViewSectionDto>> GetSectionsAsync(Guid venueId, CancellationToken cancellationToken = default);
    }
}
