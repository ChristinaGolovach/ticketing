using Ticketing.Shared.Infrastructure.Bus.Models;

namespace Modules.Notifications.Service.Factory
{
    public interface INotificationFactory : IDisposable
    {
        INotificationService GetNotificationService(NotificationType type);
    }
}
