using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Ticketing.Shared.Infrastructure.Bus
{
    public class BusService : IBusService
    {
        private readonly ServiceBusSender _sender;

        public BusService(
             ServiceBusClient client,
             IOptions<BusConfigurations> serviceBusOptions)
        {
            _sender = client.CreateSender(serviceBusOptions.Value.QueueName);
        }

        public async Task SendMessageAsync<T>(T notification, CancellationToken cancellationToken)
        {
            // TODO: dynamic queueName instead of  _sender = client.CreateSender(serviceBusOptions.Value.QueueName);

            var body = JsonSerializer.Serialize(notification);
            var message = new ServiceBusMessage(body);

            await _sender.SendMessageAsync(message, cancellationToken);
        }

        public async ValueTask DisposeAsync()
        {
            if (_sender != null)
            {
                await _sender.DisposeAsync();
            }
        }
    }
}
