using Modules.Orders.Data.Entities;
using Modules.Orders.Infrastructure.Data;

namespace TicketingIntegrationTests.InMemoryDB
{
    public class OrderDbSeed
    {
        public void DataSeed(OrdersDBContext context)
        {
            SeedOrder(context);
            SeedOrderItems(context);
        }

        private void SeedOrder(OrdersDBContext context)
        {
            context.Orders.AddRange(
                new Order { Id = new Guid("43ae8ddc-0528-4d89-b947-08b12b688b89"), Status = 0, Amount = 0, UserId = new Guid("c4b4f2ba-67f7-4193-8406-89f269081b6c"), ActivityId = new Guid("8B5FA894-DFCF-4BB4-A605-5F99985C3805") });
                //new Order { Id = new Guid("57da6160-0567-436a-92d7-eeb3d109b8f9"), Status = OrderStatus.InProgress, Amount = 0, UserId = new Guid("478efca6-3ee2-44d7-8abd-521301231e8b"), ActivityId = new Guid("8B5FA894-DFCF-4BB4-A605-5F99985C3805") }); 
        }

        private void SeedOrderItems(OrdersDBContext context)
        {
            //context.OrderItems.AddRange(
            //    new OrderItem { Id = new Guid("8c9922e2-98fa-4bfd-82bc-5930db899848"), Amount = 250, OrderId = new Guid("43ae8ddc-0528-4d89-b947-08b12b688b89"), ActivitySeatId = new Guid("28eeaa98-3068-4a7a-8b6e-4457d81d5312") },
            //    new OrderItem { Id = new Guid("b588359f-97c6-46fa-9c3d-e4f5098c0218"), Amount = 250, OrderId = new Guid("43ae8ddc-0528-4d89-b947-08b12b688b89"), ActivitySeatId = new Guid("d4016119-36b7-459a-a79f-534f5d69efb3") },
            //    new OrderItem { Id = new Guid("83e6feed-73e5-4db2-a192-97310ab2b8d5"), Amount = 250, OrderId = new Guid("43ae8ddc-0528-4d89-b947-08b12b688b89"), ActivitySeatId = new Guid("433cf7f1-ca84-46fe-9eed-d33124b84acd") });
        }
    }
}
