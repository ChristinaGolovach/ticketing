using Modules.Orders.Data.Entities;

namespace Modules.Orders.Core.UnitTest.FakeData
{
    public class FakeOrders
    {
        public static IQueryable<Order> CreateFakeOrders()
        {
            var orderItems = new List<Order>()
            {
                new Order
                {
                    Id = new Guid("cc99afbd-c379-4ba0-910b-3c4849192a5c"),
                    UserId = new Guid("8cb145fc-42fd-4aad-82b9-f8a8c8e3bdab"),
                    Amount = 300,
                    OrderItems = new List<OrderItem>()
                    {
                        new OrderItem
                        {
                            ActivitySeatId = new Guid("d13f6a1e-fe24-4ac0-be2d-aa0ba154ce27"),
                        },
                        new OrderItem
                        {
                            ActivitySeatId = new Guid("f788aece-ea71-44de-8407-cfd06275af0c"),
                        }
                    },
                    Deleted = false
                },
                new Order
                {
                    Id = new Guid("cf970046-3124-4e9b-83c6-002b24d8eea4"),
                    UserId = new Guid("bae97295-a71a-45fa-a3ce-554fdeeb0475"),
                    Amount = 400,
                    OrderItems = new List<OrderItem>()
                    {
                        new OrderItem
                        {
                            ActivitySeatId = new Guid("c8a634be-84e4-4cf2-894f-35fff52caee7"),
                        },
                        new OrderItem
                        {
                           ActivitySeatId = new Guid("a54fb9b7-f419-438b-be18-e4da6266bef2"),
                        }
                    },
                    Deleted = false
                },
                new Order
                {
                    Id = new Guid("d7018d7a-3ce3-4083-aabe-e610f21a1e0d"),
                    UserId = new Guid("da18b8db-0fbb-42b9-9197-b0db28f740f9"),
                    Amount = 500,
                    Deleted = true
                },
                new Order
                {
                    Id = new Guid("9f6b9d51-8c70-4294-932a-b3919e2cce7d"),
                    UserId = new Guid("1c32d74f-d1fa-4870-ae4e-fefcf00926c7"),
                    Amount = 600,
                    Deleted = true
                }
            }.AsQueryable();

            return orderItems;
        }
    }
}
