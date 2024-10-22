using MockQueryable;
using Moq;
using Xunit;

using Modules.Orders.Core.Services;
using Modules.Orders.Data.Entities;
using Modules.Orders.Infrastructure.Data;
using Ticketing.Shared.Core.Exceptions;
using Ticketing.Shared.Infrastructure.Data;
using Modules.Orders.Core.Models.Dtos;

namespace Modules.Orders.Core.UnitTest
{
    public class OrderItemServiceTests
    {
        private readonly Mock<IRepository<OrderItem, OrdersDBContext>> _repositoryMock;
        private readonly IQueryable<OrderItem> _orderItems;

        public OrderItemServiceTests()
        {
            _orderItems = CreateFakeOrderItems();
            _repositoryMock = new Mock<IRepository<OrderItem, OrdersDBContext>>();
            _repositoryMock.Setup(r => r.Query()).Returns(_orderItems.BuildMock());
        }


        [Theory]
        [InlineData("87b6b120-63c0-4e8e-93f8-d827be176a5e", "1983322c-c029-43c1-96af-b22d2da95dca", 23.5)]
        [InlineData("7796e9a7-4e0a-4a2a-957e-a4f6f61b2f7c", "5082ba5b-a4c9-406d-be22-3a91063d9d08", 23.8)]

        public async Task AddOrderItem_Should_CallRepositoryWithCorrespondingOrderItem(string orderGuidId, string activitySeatGuidId, double amount)
        {
            // Arrange
            var orderId = new Guid(orderGuidId);
            var activitySeatId = new Guid(activitySeatGuidId);

            var activitySeat = new AddSeatDto
            {
                ActivitySeatId = activitySeatId,
                Amount = amount
            };
            var orderItem = new OrderItem
            {
                OrderId = orderId,
                ActivitySeatId = activitySeatId,
                Amount = amount
            };

            var sut = new OrderItemService(_repositoryMock.Object);

            // Act
            await sut.AddOrderItemAsync(orderId, activitySeat);

            // Assert
            // TODO: ask if we should check the calls to repository.
            _repositoryMock.Verify(s => s.AddAsync(It.Is<OrderItem>(i =>
                i.OrderId == orderId &&
                i.ActivitySeatId == activitySeatId &&
                i.Amount == amount), default),
            Times.Once);
        }

        [Theory]
        [InlineData("8cb145fc-42fd-4aad-82b9-f8a8c8e3bdab")]
        [InlineData("bae97295-a71a-45fa-a3ce-554fdeeb0475")]
        public async Task DeleteOrderItem_Should_CalRepositoryWithCorrespondingOrderItem(string activitySeatGuidId)
        {
            // Arrange
            var activitySeatId = new Guid(activitySeatGuidId);
            var sut = new OrderItemService(_repositoryMock.Object);
            var deletedOrderItem = _orderItems.FirstOrDefault(item => item.ActivitySeatId == activitySeatId);

            // Act
            await sut.DeleteOrderItemAsync(activitySeatId);

            // Assert
            // TODO: ask if we should check the calls to repository.
            _repositoryMock.Verify(s => s.Delete(deletedOrderItem), Times.Once);
        }

        [Theory]
        [InlineData("51e89746-3a8f-4526-8bb2-587898d59b39")]
        [InlineData("0b310262-c1d2-433a-ad21-b0ecece41914")]
        public async Task DeleteOrderItem_Should_ThrowException_WhenSeatNotExist(string activitySeatGuidId)
        {
            // Arrange
            var activitySeatId = new Guid(activitySeatGuidId);
            var sut = new OrderItemService(_repositoryMock.Object);

            // Act - Assert
            await Assert.ThrowsAsync<ResourceNotFoundException>(() => sut.DeleteOrderItemAsync(activitySeatId));
        }

        [Theory]
        [InlineData("da18b8db-0fbb-42b9-9197-b0db28f740f9")]
        [InlineData("1c32d74f-d1fa-4870-ae4e-fefcf00926c7")]
        public async Task DeleteOrderItem_Should_ThrowException_WhenIsAlreadyDeleted(string activitySeatGuidId)
        {
            // Arrange
            var activitySeatId = new Guid(activitySeatGuidId);
            var sut = new OrderItemService(_repositoryMock.Object);

            // Act - Assert
            await Assert.ThrowsAsync<ResourceNotFoundException>(() => sut.DeleteOrderItemAsync(activitySeatId));
        }

        private IQueryable<OrderItem> CreateFakeOrderItems()
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
