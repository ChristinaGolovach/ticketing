using Modules.Events.Core.Models;
using Modules.Events.Data.Entities;

namespace Modules.Events.Core.Services
{
    public interface IActivitySeatService
    {
        Task<ViewActivitySeatDto> GetActivitySeatAsync(Guid activitySeatId, CancellationToken cancellationToken = default);
        Task UpdateActivitySeatStateAsync(IList<Guid> activitySeatIds, SeatState state, CancellationToken cancellationToken = default);
        Task UpdateActivitySeatStateAsync(IDictionary<Guid, byte[]> activitySeatIds, SeatState state, CancellationToken cancellationToken = default);
        Task<SeatState> GetActivitySeatStateAsync(Guid activitySeatId, CancellationToken cancellationToken = default);
    }
}
