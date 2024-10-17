using Modules.Events.Core.Models;
using Modules.Events.Data.Entities;

namespace Modules.Events.Core.Services
{
    public interface IActivityService
    {
        Task<IList<ViewActivityDto>> GetActivitiesAsync(CancellationToken cancellationToken = default);
        Task<IList<ViewActivitySeatDto>> GetSeatsAsync(Guid activityId, Guid sectionId, CancellationToken cancellationToken = default);
    }
}
