using Microsoft.Extensions.DependencyInjection;
using Modules.Notifications.Service.EmailNotifications;
using Ticketing.Shared.Infrastructure.Bus.Models;

namespace Modules.Notifications.Service.Factory
{
    public class NotificationFactory : INotificationFactory
    {
        private readonly IServiceScope _scope;

        public NotificationFactory(IServiceProvider serviceProvider)
        {
            _scope = serviceProvider.CreateScope();
        }

        public INotificationService GetNotificationService(NotificationType type)
        {
            switch (type)
            {
                case NotificationType.Email:
                    return _scope.ServiceProvider.GetRequiredService<IEmailNotificationService>();
                case NotificationType.SMS:
                    throw new NotImplementedException($"Not implemented {nameof(NotificationType)} - [{type}].");
                default:
                    throw new NotSupportedException($"Invalid value {nameof(NotificationType)} - [{type}].");
            }
        }

        public void Dispose()
        {
            _scope?.Dispose();
        }
    }
}
