using Modules.Orders.Data.Entities;

namespace Modules.Orders.Core.UnitTest.FakeData
{
    public class FakeOrderItems
    {
        public static IQueryable<OrderItem> CreateFakeOrderItems()
        {
            var orderItems = new List<OrderItem>()
            {
                new OrderItem
                {
                    Id = new Guid("cc99afbd-c379-4ba0-910b-3c4849192a5c"),
                    ActivitySeatId = new Guid("8cb145fc-42fd-4aad-82b9-f8a8c8e3bdab"),
                    Deleted = false
                },
                new OrderItem
                {
                    Id = new Guid("cf970046-3124-4e9b-83c6-002b24d8eea4"),
                    ActivitySeatId = new Guid("bae97295-a71a-45fa-a3ce-554fdeeb0475"),
                    Deleted = false
                },
                new OrderItem
                {
                    Id = new Guid("d7018d7a-3ce3-4083-aabe-e610f21a1e0d"),
                    ActivitySeatId = new Guid("da18b8db-0fbb-42b9-9197-b0db28f740f9"),
                    Deleted = true
                },
                new OrderItem
                {
                    Id = new Guid("9f6b9d51-8c70-4294-932a-b3919e2cce7d"),
                    ActivitySeatId = new Guid("1c32d74f-d1fa-4870-ae4e-fefcf00926c7"),
                    Deleted = true
                }
            }.AsQueryable();

            return orderItems;
        }
    }
}
