using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Modules.Notifications.Service.EmailNotifications;
using Modules.Notifications.Service.Factory;
using Modules.Notifications.Service.Models;
using SendGrid;
using Ticketing.Shared.Infrastructure.Bus;

namespace Modules.Notifications.Service
{
    public static class ServiceExtensions
    {
        public static void AddNotificationService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SendgridConfigurations>(configuration.GetSection(nameof(SendgridConfigurations)));
            services.Configure<NotificationsConfigurations>(configuration.GetSection(nameof(NotificationsConfigurations)));

            services.AddSingleton<INotificationFactory, NotificationFactory>();
            services.AddSingleton<IEmailNotificationService, EmailNotificationService>();

            services.AddSingleton<ISendGridClient, SendGridClient>(serviceProvider =>
            {
                var options = serviceProvider.GetService<IOptions<SendgridConfigurations>>().Value;
                return new SendGridClient(options.ApiKey);
            });

            services.AddHostedService<NotificationsBackgroundService>();
        }
    }
}
