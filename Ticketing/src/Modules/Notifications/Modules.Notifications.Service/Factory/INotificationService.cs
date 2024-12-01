using Ticketing.Shared.Infrastructure.Bus.Models;

namespace Modules.Notifications.Service.Factory
{
    public interface INotificationService
    {
        Task SendNotificationAsync(NotificationDto notification, CancellationToken cancellationToken);
    }
}
