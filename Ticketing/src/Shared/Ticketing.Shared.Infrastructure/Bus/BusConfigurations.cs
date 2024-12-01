using Azure.Messaging.ServiceBus;

namespace Ticketing.Shared.Infrastructure.Bus
{
    public class BusConfigurations
    {
        public string ConnectionString { get; set; }
        public string QueueName { get; set; }
        public int RetryCount { get; set; }
        public int RetryDelayInSeconds { get; set; }

        public ServiceBusClientOptions GetClientOptions()
        {
            return new ServiceBusClientOptions()
            {
                TransportType = ServiceBusTransportType.AmqpWebSockets,
                RetryOptions = new ServiceBusRetryOptions
                {
                    Delay = TimeSpan.FromSeconds(1),
                    Mode = ServiceBusRetryMode.Fixed,
                    MaxRetries = RetryCount,
                    MaxDelay = TimeSpan.FromSeconds(RetryDelayInSeconds),
                },
            };
        }
    }
}
