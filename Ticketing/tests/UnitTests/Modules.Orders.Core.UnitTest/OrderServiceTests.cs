using AutoMapper;
using MediatR;
using MockQueryable;
using Moq;
using Xunit;

using Modules.Orders.Core.Services;
using Modules.Orders.Data.Entities;
using Modules.Orders.Infrastructure.Data;
using Ticketing.Shared.Infrastructure.Data;
using Ticketing.Shared.Core.Exceptions;
using Modules.Orders.Core.Models.Dtos;
using Modules.Orders.Core.UnitTest.FakeData;
using Modules.Orders.Core.Models;
using Ticketing.Shared.Messaging.Requests;

namespace Modules.Orders.Core.UnitTest
{
    public class OrderServiceTests
    {
        private readonly Mock<IRepository<Order, OrdersDBContext>> _repositoryMock;
        private readonly Mock<IOrderItemService> _orderItemServiceMock;
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly IQueryable<Order> _orders;

        public OrderServiceTests()
        {
            _orders = FakeOrders.CreateFakeOrders();

            _repositoryMock = new Mock<IRepository<Order, OrdersDBContext>>();
            _orderItemServiceMock = new Mock<IOrderItemService>();
            _mediatorMock = new Mock<IMediator>();
            _mapperMock = new Mock<IMapper>();

            ConfigureMocks();
        }

        [Theory]
        [InlineData("87b6b120-63c0-4e8e-93f8-d827be176a5e", "8cb145fc-42fd-4aad-82b9-f8a8c8e3bdab")]
        [InlineData("7796e9a7-4e0a-4a2a-957e-a4f6f61b2f7c", "8cb145fc-42fd-4aad-82b9-f8a8c8e3bdab")]
        public async Task GetOrder_Should_ThrowException_WhenOrderIdIsWrong(string orderGuidId, string userGuidId)
        {
            // Arrange
            var orderId = new Guid(orderGuidId);
            var userId = new Guid(userGuidId);

            var sut = new OrderService(_repositoryMock.Object,
                _orderItemServiceMock.Object,
                _mediatorMock.Object,
                _mapperMock.Object);

            // Act - Asser
            await Assert.ThrowsAsync<ResourceNotFoundException>(() => sut.GetOrderAsync(userId, orderId));
        }

        [Theory]
        [InlineData("cc99afbd-c379-4ba0-910b-3c4849192a5c", "87b6b120-63c0-4e8e-93f8-d827be176a5e")]
        [InlineData("cf970046-3124-4e9b-83c6-002b24d8eea4", "7796e9a7-4e0a-4a2a-957e-a4f6f61b2f7c")]
        public async Task GetOrder_Should_ThrowException_WhenUserIdIsWrong(string orderGuidId, string userGuidId)
        {
            // Arrange
            var orderId = new Guid(orderGuidId);
            var userId = new Guid(userGuidId);

            var sut = new OrderService(_repositoryMock.Object,
                _orderItemServiceMock.Object,
                _mediatorMock.Object,
                _mapperMock.Object);

            // Act - Asser
            await Assert.ThrowsAsync<ResourceNotFoundException>(() => sut.GetOrderAsync(userId, orderId));
        }

        [Theory]
        [InlineData("cc99afbd-c379-4ba0-910b-3c4849192a5c", "8cb145fc-42fd-4aad-82b9-f8a8c8e3bdab")]
        [InlineData("cf970046-3124-4e9b-83c6-002b24d8eea4", "bae97295-a71a-45fa-a3ce-554fdeeb0475")]
        public async Task GetOrder_Should_ReturnOrder(string orderGuidId, string userGuidId)
        {
            // Arrange
            var orderId = new Guid(orderGuidId);
            var userId = new Guid(userGuidId);

            var sut = new OrderService(_repositoryMock.Object,
                _orderItemServiceMock.Object,
                _mediatorMock.Object,
                _mapperMock.Object);

            // Act
            var result = await sut.GetOrderAsync(userId, orderId);

            // Asser
            Assert.NotNull(result);
            Assert.Equal(orderId, result.Id);
        }

        [Theory]
        [InlineData("87b6b120-63c0-4e8e-93f8-d827be176a5e")]
        [InlineData("7796e9a7-4e0a-4a2a-957e-a4f6f61b2f7c")]
        public async Task AddSeat_Should_ThrowException_WhenOrderIdIsWrong(string orderGuidId)
        {
            // Arrange
            var orderId = new Guid(orderGuidId);

            var sut = new OrderService(_repositoryMock.Object,
                _orderItemServiceMock.Object,
                _mediatorMock.Object,
                _mapperMock.Object);

            // Act - Asser
            await Assert.ThrowsAsync<ResourceNotFoundException>(() => sut.AddSeatAsync(orderId, new AddSeatDto()));
        }

        [Theory]
        [InlineData("cc99afbd-c379-4ba0-910b-3c4849192a5c", "d13f6a1e-fe24-4ac0-be2d-aa0ba154ce27")]
        [InlineData("cf970046-3124-4e9b-83c6-002b24d8eea4", "c8a634be-84e4-4cf2-894f-35fff52caee7")]
        public async Task AddSeat_Should_ThrowException_WhenSeatIsAlreadyAdded(string orderGuidId, string activitySeatGuidId)
        {
            // Arrange
            var orderId = new Guid(orderGuidId);
            var activitySeatId = new Guid(activitySeatGuidId);
            var activitySeat = new AddSeatDto { ActivitySeatId = activitySeatId };

            var sut = new OrderService(_repositoryMock.Object,
                _orderItemServiceMock.Object,
                _mediatorMock.Object,
                _mapperMock.Object);

            // Act - Asser
            await Assert.ThrowsAsync<ResourceDuplicateException>(() => sut.AddSeatAsync(orderId, activitySeat));
        }

        [Theory]
        [InlineData("cc99afbd-c379-4ba0-910b-3c4849192a5c", "cc291472-cac8-4275-8fa1-1479f3904b10", 150)]
        [InlineData("cf970046-3124-4e9b-83c6-002b24d8eea4", "aea8084b-6ca9-4fc7-b8d5-fad52617957b", 121.2)]
        public async Task AddSeat_Should_IncreaseAmountOfCorrespondOrderByAmountFromSeat(string orderGuidId, string activitySeatGuidId, double amount)
        {
            // Arrange
            var orderId = new Guid(orderGuidId);
            var activitySeatId = new Guid(activitySeatGuidId);
            var activitySeat = new AddSeatDto { ActivitySeatId = activitySeatId , Amount = amount };

            var sut = new OrderService(_repositoryMock.Object,
                _orderItemServiceMock.Object,
                _mediatorMock.Object,
                _mapperMock.Object);

            var order = _orders.First(o => o.Id == orderId);
            var exceptedResult = order.Amount + amount;

            // Act
            var actualResult = await sut.AddSeatAsync(orderId, activitySeat);

            // Asser
            Assert.Equal(exceptedResult, actualResult.Amount);
            Assert.Equal(orderId, actualResult.Id);
        }

        [Theory]
        [InlineData("cc99afbd-c379-4ba0-910b-3c4849192a5c", OrderAction.Submit)]
        [InlineData("cf970046-3124-4e9b-83c6-002b24d8eea4", OrderAction.Submit)]
        public async Task ApplyAction_Should_ChangeOrderStatusToInProgress_WhenActionIsSubmit(string orderGuidId, OrderAction action)
        {
            // Arrange
            var orderId = new Guid(orderGuidId);

            var sut = new OrderService(_repositoryMock.Object,
                _orderItemServiceMock.Object,
                _mediatorMock.Object,
                _mapperMock.Object);

            var expectedResult = new Order { Id = orderId, Status = OrderStatus.InProgress };

            // Act
            var actualResponseResult = await sut.ApplyActionAsync(orderId, action);
            var actualResult = _orders.First(o => o.Id == orderId);

            // Asser
            Assert.Equal(expectedResult.Status, actualResult.Status);
            Assert.Equal(expectedResult.Id, actualResult.Id);
        }

        [Theory]
        [InlineData("cc99afbd-c379-4ba0-910b-3c4849192a5c", OrderAction.Submit)]
        [InlineData("cf970046-3124-4e9b-83c6-002b24d8eea4", OrderAction.Submit)]
        public async Task ApplyAction_Should_RequestSeatBiking_WhenActionIsSubmit(string orderGuidId, OrderAction action)
        {
            // Arrange
            var orderId = new Guid(orderGuidId);

            var sut = new OrderService(_repositoryMock.Object,
                _orderItemServiceMock.Object,
                _mediatorMock.Object,
                _mapperMock.Object);

            // Act
            var actualResponseResult = await sut.ApplyActionAsync(orderId, action);

            // Asser
            _mediatorMock.Verify(m => m.Send(It.IsAny<SeatBookRequest>(), default), Times.Once);
        }

        [Theory]
        [InlineData("cc99afbd-c379-4ba0-910b-3c4849192a5c", OrderAction.Submit)]
        [InlineData("cf970046-3124-4e9b-83c6-002b24d8eea4", OrderAction.Submit)]
        public async Task ApplyAction_Should_RequestPaymentCreationForOrder_WhenActionIsSubmit(string orderGuidId, OrderAction action)
        {
            // Arrange
            var orderId = new Guid(orderGuidId);

            var sut = new OrderService(_repositoryMock.Object,
                _orderItemServiceMock.Object,
                _mediatorMock.Object,
                _mapperMock.Object);

            var order = _orders.First(o => o.Id == orderId);

            // Act
            var actualResponseResult = await sut.ApplyActionAsync(orderId, action);

            // Asser
            _mediatorMock.Verify(m =>
                m.Send(It.Is<PaymentNewRequest>(p => p.OrderId == orderId && p.Amount == order.Amount), default),
                Times.Once);
        }

        [Theory]
        [InlineData("cc99afbd-c379-4ba0-910b-3c4849192a5c", (OrderAction)0)]
        public async Task ApplyAction_Should_ThrowException_WhenActionIsUnknown(string orderGuidId, OrderAction action)
        {
            // Arrange
            var orderId = new Guid(orderGuidId);

            var sut = new OrderService(_repositoryMock.Object,
                _orderItemServiceMock.Object,
                _mediatorMock.Object,
                _mapperMock.Object);

            // Act - Asser
            await Assert.ThrowsAsync<MethodNotAllowedException>(() => sut.ApplyActionAsync(orderId, action));
        }

        [Theory]
        [InlineData("08b30ede-7efc-4d16-9809-dbf1467aae92", "d13f6a1e-fe24-4ac0-be2d-aa0ba154ce27")]
        [InlineData("88f9a052-31f5-4bbd-b24c-d0c9f2ce5b1f", "c8a634be-84e4-4cf2-894f-35fff52caee7")]
        public async Task DeleteSeat_Should_ThrowException_WhenOrderIsWrong(string orderGuidId, string activitySeatGuidId)
        {
            // Arrange
            var orderId = new Guid(orderGuidId);
            var activitySeatId = new Guid(activitySeatGuidId);

            var sut = new OrderService(_repositoryMock.Object,
                _orderItemServiceMock.Object,
                _mediatorMock.Object,
                _mapperMock.Object);

            // Act - Asser
            await Assert.ThrowsAsync<ResourceNotFoundException>(() => sut.DeleteSeatAsync(orderId, activitySeatId));
        }

        [Theory]
        [InlineData("d7018d7a-3ce3-4083-aabe-e610f21a1e0d", "d13f6a1e-fe24-4ac0-be2d-aa0ba154ce27")]
        [InlineData("9f6b9d51-8c70-4294-932a-b3919e2cce7d", "c8a634be-84e4-4cf2-894f-35fff52caee7")]
        public async Task DeleteSeat_Should_ThrowException_WhenOrderIsDeletedAlready(string orderGuidId, string activitySeatGuidId)
        {
            // Arrange
            var orderId = new Guid(orderGuidId);
            var activitySeatId = new Guid(activitySeatGuidId);

            var sut = new OrderService(_repositoryMock.Object,
                _orderItemServiceMock.Object,
                _mediatorMock.Object,
                _mapperMock.Object);

            // Act - Asser
            await Assert.ThrowsAsync<ResourceNotFoundException>(() => sut.DeleteSeatAsync(orderId, activitySeatId));
        }


        [Theory]
        [InlineData("cc99afbd-c379-4ba0-910b-3c4849192a5c", OrderStatus.Failed)]
        [InlineData("cf970046-3124-4e9b-83c6-002b24d8eea4", OrderStatus.Paid)]
        public async Task UpdateOrderStatus_Should_UpdateStatus(string orderGuidId, OrderStatus status)
        {
            // Arrange
            var orderId = new Guid(orderGuidId);

            var sut = new OrderService(_repositoryMock.Object,
                _orderItemServiceMock.Object,
                _mediatorMock.Object,
                _mapperMock.Object);

            // Act
            await sut.UpdateOrderStatusAsync(orderId, status);
            var order = _orders.First(o => o.Id == orderId);

            // Asser
            Assert.Equal(status, order.Status);
        }

        [Theory]
        [InlineData("cc99afbd-c379-4ba0-910b-3c4849192a5c", OrderStatus.Failed)]
        [InlineData("cf970046-3124-4e9b-83c6-002b24d8eea4", OrderStatus.Failed)]
        public async Task UpdateOrderStatus_Should_RequestSeatResetToAvailableState_WhenStatusIsFailed(string orderGuidId, OrderStatus status)
        {
            // Arrange
            var orderId = new Guid(orderGuidId);

            var sut = new OrderService(_repositoryMock.Object,
                _orderItemServiceMock.Object,
                _mediatorMock.Object,
                _mapperMock.Object);

            // Act
            await sut.UpdateOrderStatusAsync(orderId, status);

            // Asser
            _mediatorMock.Verify(m => m.Send(It.IsAny<SeatAvailableRequest>(), default), Times.Once);
        }

        [Theory]
        [InlineData("cc99afbd-c379-4ba0-910b-3c4849192a5c", OrderStatus.Failed)]
        [InlineData("cf970046-3124-4e9b-83c6-002b24d8eea4", OrderStatus.Failed)]
        public async Task UpdateOrderStatus_ShouldNot_RequestSeatSold_WhenStatusIsFailed(string orderGuidId, OrderStatus status)
        {
            // Arrange
            var orderId = new Guid(orderGuidId);

            var sut = new OrderService(_repositoryMock.Object,
                _orderItemServiceMock.Object,
                _mediatorMock.Object,
                _mapperMock.Object);

            // Act
            await sut.UpdateOrderStatusAsync(orderId, status);

            // Asser
            _mediatorMock.Verify(m => m.Send(It.IsAny<SeatSoldRequest>(), default), Times.Never);
        }

        [Theory]
        [InlineData("cc99afbd-c379-4ba0-910b-3c4849192a5c", OrderStatus.Paid)]
        [InlineData("cf970046-3124-4e9b-83c6-002b24d8eea4", OrderStatus.Paid)]
        public async Task UpdateOrderStatus_Should_RequestSeatSold_WhenStatusIsPaid(string orderGuidId, OrderStatus status)
        {
            // Arrange
            var orderId = new Guid(orderGuidId);

            var sut = new OrderService(_repositoryMock.Object,
                _orderItemServiceMock.Object,
                _mediatorMock.Object,
                _mapperMock.Object);

            // Act
            await sut.UpdateOrderStatusAsync(orderId, status);

            // Asser
            _mediatorMock.Verify(m => m.Send(It.IsAny<SeatSoldRequest>(), default), Times.Once);
        }

        [Theory]
        [InlineData("cc99afbd-c379-4ba0-910b-3c4849192a5c", OrderStatus.Paid)]
        [InlineData("cf970046-3124-4e9b-83c6-002b24d8eea4", OrderStatus.Paid)]
        public async Task UpdateOrderStatus_ShouldNot_RequestSeatResetToAvailableState_WhenStatusIsPaid(string orderGuidId, OrderStatus status)
        {
            // Arrange
            var orderId = new Guid(orderGuidId);

            var sut = new OrderService(_repositoryMock.Object,
                _orderItemServiceMock.Object,
                _mediatorMock.Object,
                _mapperMock.Object);

            // Act
            await sut.UpdateOrderStatusAsync(orderId, status);

            // Asser
            _mediatorMock.Verify(m => m.Send(It.IsAny<SeatAvailableRequest>(), default), Times.Never);
        }

        private void ConfigureMocks()
        {
            _repositoryMock.Setup(r => r.Query()).Returns(_orders.BuildMock());

            _mapperMock.Setup(m => m.Map<ViewOrderDto>(It.IsAny<Order>()))
                .Returns((Order order) => new ViewOrderDto
                {
                    Id = order.Id,
                    ActivityId = order.ActivityId,
                    Amount = order.Amount,
                    OrderItems = order.OrderItems
                        .Select(i => new ViewOrderItemDto { Id = i.Id, ActivitySeatId = i.ActivitySeatId })
                        .ToList(),
                });
        }
    }
}
