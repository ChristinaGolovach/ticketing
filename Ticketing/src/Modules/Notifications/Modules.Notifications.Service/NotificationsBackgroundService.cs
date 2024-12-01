using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

using Modules.Notifications.Service.Factory;
using Ticketing.Shared.Infrastructure.Bus;
using Ticketing.Shared.Infrastructure.Bus.Models;

namespace Modules.Notifications.Service
{
    public class NotificationsBackgroundService : IHostedService, IAsyncDisposable
    {
        private readonly ServiceBusProcessor _processor;
        private readonly INotificationFactory _notificationFactory;
        private readonly ILogger<NotificationsBackgroundService> _logger;

        public NotificationsBackgroundService(
            ServiceBusClient serviceBusClient,
            INotificationFactory notificationFactory,
            ILogger<NotificationsBackgroundService> logger,
            IOptions<BusConfigurations> serviceBusOptions)
        {
            _notificationFactory = notificationFactory;
            _logger = logger;

            _processor = serviceBusClient.CreateProcessor(serviceBusOptions.Value.QueueName, new ServiceBusProcessorOptions());
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Notifications Background Service is starting.");

            try
            {
                _processor.ProcessMessageAsync += MessageHandler;
                _processor.ProcessErrorAsync += ErrorHandler;

                await _processor.StartProcessingAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred in Notifications Background Service.");
            }
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Notifications Background Service is stopping.");

            _logger.LogInformation("\nStopping the receiver...");
            await _processor.StopProcessingAsync(cancellationToken);
            _logger.LogInformation("Stopped receiving messages");

            await _processor.CloseAsync(cancellationToken);
        }

        public async ValueTask DisposeAsync()
        {
            if (_processor != null)
            {
                await _processor.DisposeAsync();
            }
        }

        public void Dispose()
        {
            _processor?.DisposeAsync();
        }

        private async Task MessageHandler(ProcessMessageEventArgs message)
        {
            var notificationMessageJson = Encoding.UTF8.GetString(message.Message.Body.ToArray());

            _logger.LogInformation($"Received message: [{notificationMessageJson}].");

            var notificationMessage = JsonSerializer.Deserialize<NotificationDto>(notificationMessageJson);

            try
            {
                var service = _notificationFactory.GetNotificationService(notificationMessage.Type);
                await service.SendNotificationAsync(notificationMessage, message.CancellationToken);

                // TODO: save to database. And add service to update DB state.

                await message.CompleteMessageAsync(message.Message, message.CancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to send email after retries: [{ex.Message}].");
            }
        }

        private Task ErrorHandler(ProcessErrorEventArgs args)
        {
            _logger.LogError($"Error: [{args}].");
            return Task.CompletedTask;
        }
    }
}
