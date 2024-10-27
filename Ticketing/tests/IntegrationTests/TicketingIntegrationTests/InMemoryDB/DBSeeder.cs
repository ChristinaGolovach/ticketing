using Microsoft.Extensions.DependencyInjection;
using Modules.Events.Infrastructure.Data;
using Modules.Orders.Infrastructure.Data;
using Modules.Payments.Infrastructure.Data;

namespace TicketingIntegrationTests.InMemoryDB
{
    public class DBSeeder
    {
        public void SeedDatabase(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;

                var activityDbContext = scopedServices.GetRequiredService<EventsDBContext>();
                var orderDbContext = scopedServices.GetRequiredService<OrdersDBContext>();
                var paymentContext = scopedServices.GetRequiredService<PaymentsDBContext>();

                new ActivityDdSeed().DataSeed(activityDbContext);
                activityDbContext.SaveChanges();

                new OrderDbSeed().DataSeed(orderDbContext);
                orderDbContext.SaveChanges();

                new PaymentDbSeed().DataSeed(paymentContext);
                paymentContext.SaveChanges();
            }
        }
    }
}
