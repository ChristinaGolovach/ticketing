using Modules.Events.Data.Entities;

namespace Modules.Events.Core.Services
{
    public interface IActivitySeatService
    {
        Task UpdateActivitySeatStateAsync(IList<Guid> activitySeatIds, SeatState state, CancellationToken cancellationToken = default);
    }
}
