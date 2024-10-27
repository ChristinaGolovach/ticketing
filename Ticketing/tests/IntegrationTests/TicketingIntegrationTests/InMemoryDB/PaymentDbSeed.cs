using Modules.Payments.Data.Entities;
using Modules.Payments.Infrastructure.Data;

namespace TicketingIntegrationTests.InMemoryDB
{
    public class PaymentDbSeed
    {
        public void DataSeed(PaymentsDBContext context)
        {
            context.Payments.Add(
            new Payment
            {
                Id = new Guid("13da23f6-61d7-46a2-827f-53f6dfc87621"),
                OrderId = new Guid("43ae8ddc-0528-4d89-b947-08b12b688b89"),
                Status = PaymentStatus.InProcess
            });
        }
    }
}
