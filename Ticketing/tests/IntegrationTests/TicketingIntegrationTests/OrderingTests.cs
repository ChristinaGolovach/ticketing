using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Json;
using Xunit;

using Modules.Events.Core.Models;
using Modules.Events.Data.Entities;
using Modules.Events.Infrastructure.Data;
using Modules.Orders.Core.Models;
using Modules.Orders.Core.Models.Dtos;
using Modules.Orders.Data.Entities;
using Modules.Payments.Core.Models;
using Modules.Payments.Data.Entities;
using TicketingIntegrationTests.Configuration;

namespace TicketingIntegrationTests
{
    public class PaymentsControllerTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory _factory;

        public PaymentsControllerTests(CustomWebApplicationFactory factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CompletePayment_ShouldBe_OrderStatusIsPaid_SeatsAreSold_WhenPaymentIsCompleted()
        {
            #region Get seats of the Activity
            // Arrange - Activity
            var activityId = new Guid("8B5FA894-DFCF-4BB4-A605-5F99985C3805");
            var sectionId = new Guid("B6A3C9E9-B7F5-425D-A716-D2D7F788F423");

            // Act - Activity
            var seatsResponse = await _client.GetAsync($"/api/activities/{activityId}/sections/{sectionId}/seats");
            var seats = await Utils.GetRequestContent<IList<ViewActivitySeatDto>>(seatsResponse);

            // Assert - Activity
            seatsResponse.EnsureSuccessStatusCode();
            Assert.NotNull(seats);
            Assert.True(seats.Count > 0);
            #endregion

            #region Add seats to the Order
            // Arrange - Order
            var orderId = new Guid("43ae8ddc-0528-4d89-b947-08b12b688b89");
            var userId = new Guid("c4b4f2ba-67f7-4193-8406-89f269081b6c");
            var seatDtos = seats.Select(s => new AddSeatDto 
             {
                ActivitySeatId = s.Id,
                ActivityId = activityId,
                Amount = s.Amount
            }).ToList();
            var seatIds = seats.Select(s => s.Id).ToList();
            var seatAmountSum = seats.Sum(s => s.Amount);

            // Act - Order
            foreach (var seat in seatDtos) 
            {
                await _client.PostAsJsonAsync($"/api/orders/{orderId}", seat);
            }

            var orderResponse = await _client.GetAsync($"/api/orders/{userId}/{orderId}");
            var order = await Utils.GetRequestContent<ViewOrderDto>(orderResponse);

            // Assert - Order
            Assert.NotNull(order);
            Assert.Equal(order.Id, orderId);
            Assert.Equal(order.OrderItems.Count, seatDtos.Count);
            Assert.Equal(order.Amount, seatAmountSum);
            #endregion

            #region Submit Order
            // Act - Order
            var orderSubmitResponse = await _client.PutAsJsonAsync($"/api/orders/{orderId}/action", OrderAction.Submit);
            var submittedOrder = await Utils.GetRequestContent<OrderActionResult>(orderSubmitResponse);

            var bokedSeats = new List<ActivitySeat>();
            using (var scope = _factory.Services.CreateScope())
            {
                var activityDbContext = scope.ServiceProvider.GetRequiredService<EventsDBContext>();
                bokedSeats = activityDbContext.ActivitySeats
                    .AsNoTracking()
                    .Where(activitySeat => seatIds.Contains(activitySeat.Id)).ToList();
            }

            // Assert - Order - PaymentId - Seat's State
            Assert.NotNull(submittedOrder);
            Assert.True(submittedOrder.OrderStatus == OrderStatus.InProgress);
            Assert.True(submittedOrder.PaymentId.HasValue);
            Assert.True(Array.TrueForAll(bokedSeats.ToArray(), s => s.State == SeatState.Booked));

            #endregion

            #region Complete Payment
            // Arrange - Payment
            var paymentId = submittedOrder.PaymentId;

            // Act - Payment
            await _client.PutAsync($"/api/payments/{paymentId}/complete", null);

            var completedPaymentResponse = await _client.GetAsync($"/api/payments/{paymentId}");
            var completedPayment = await Utils.GetRequestContent<ViewPaymentDto>(completedPaymentResponse);

            var paidOrderResponse = await _client.GetAsync($"/api/orders/{userId}/{orderId}");
            var paidOrder = await Utils.GetRequestContent<ViewOrderDto>(paidOrderResponse);

            var soldSeats = new List<ActivitySeat>();
            using (var scope = _factory.Services.CreateScope())
            {
                var activityDbContext = scope.ServiceProvider.GetRequiredService<EventsDBContext>();
                bokedSeats = activityDbContext.ActivitySeats
                    .AsNoTracking()
                    .Where(activitySeat => seatIds.Contains(activitySeat.Id)).ToList();
            }

            // Assert - Payment - Order - Seats
            Assert.NotNull(completedPayment);
            Assert.True(completedPayment.Status == PaymentStatus.Paid);

            Assert.NotNull(paidOrder);
            Assert.True(paidOrder.Status == OrderStatus.Paid);

            Assert.True(completedPayment.Amount == paidOrder.Amount);

            Assert.True(Array.TrueForAll(soldSeats.ToArray(), s => s.State == SeatState.Sold));
            #endregion
        }

        [Fact]
        public async Task FailPayment_ShouldBe_OrderStatusIsFail_SeatsAreAvailable_WhenPaymentIsFailed()
        {
            #region Get seats of the Activity
            // Arrange - Activity
            var activityId = new Guid("8B5FA894-DFCF-4BB4-A605-5F99985C3805");
            var sectionId = new Guid("B6A3C9E9-B7F5-425D-A716-D2D7F788F423");

            // Act - Activity
            var seatsResponse = await _client.GetAsync($"/api/activities/{activityId}/sections/{sectionId}/seats");
            var seats = await Utils.GetRequestContent<IList<ViewActivitySeatDto>>(seatsResponse);

            // Assert - Activity
            seatsResponse.EnsureSuccessStatusCode();
            Assert.NotNull(seats);
            Assert.True(seats.Count > 0);
            #endregion

            #region Add seats to the Order
            // Arrange - Order
            var orderId = new Guid("43ae8ddc-0528-4d89-b947-08b12b688b89");
            var userId = new Guid("c4b4f2ba-67f7-4193-8406-89f269081b6c");
            var seatDtos = seats.Select(s => new AddSeatDto
            {
                ActivitySeatId = s.Id,
                ActivityId = activityId,
                Amount = s.Amount
            }).ToList();
            var seatIds = seats.Select(s => s.Id).ToList();
            var seatAmountSum = seats.Sum(s => s.Amount);

            // Act - Order
            foreach (var seat in seatDtos)
            {
                await _client.PostAsJsonAsync($"/api/orders/{orderId}", seat);
            }

            var orderResponse = await _client.GetAsync($"/api/orders/{userId}/{orderId}");
            var order = await Utils.GetRequestContent<ViewOrderDto>(orderResponse);

            // Assert - Order
            Assert.NotNull(order);
            Assert.Equal(order.Id, orderId);
            Assert.Equal(order.OrderItems.Count, seatDtos.Count);
            Assert.Equal(order.Amount, seatAmountSum);
            #endregion

            #region Submit Order
            // Act - Order
            var orderSubmitResponse = await _client.PutAsJsonAsync($"/api/orders/{orderId}/action", OrderAction.Submit);
            var submittedOrder = await Utils.GetRequestContent<OrderActionResult>(orderSubmitResponse);

            var bokedSeats = new List<ActivitySeat>();
            using (var scope = _factory.Services.CreateScope())
            {
                var activityDbContext = scope.ServiceProvider.GetRequiredService<EventsDBContext>();
                bokedSeats = activityDbContext.ActivitySeats
                    .AsNoTracking()
                    .Where(activitySeat => seatIds.Contains(activitySeat.Id)).ToList();
            }

            // Assert - Order - PaymentId - Seat's State
            Assert.NotNull(submittedOrder);
            Assert.True(submittedOrder.OrderStatus == OrderStatus.InProgress);
            Assert.True(submittedOrder.PaymentId.HasValue);
            Assert.True(Array.TrueForAll(bokedSeats.ToArray(), s => s.State == SeatState.Booked));

            #endregion

            #region Complete Payment
            // Arrange - Payment
            var paymentId = submittedOrder.PaymentId;

            // Act - Payment
            await _client.PutAsync($"/api/payments/{paymentId}/failed", null);

            var completedPaymentResponse = await _client.GetAsync($"/api/payments/{paymentId}");
            var completedPayment = await Utils.GetRequestContent<ViewPaymentDto>(completedPaymentResponse);

            var paidOrderResponse = await _client.GetAsync($"/api/orders/{userId}/{orderId}");
            var paidOrder = await Utils.GetRequestContent<ViewOrderDto>(paidOrderResponse);

            var soldSeats = new List<ActivitySeat>();
            using (var scope = _factory.Services.CreateScope())
            {
                var activityDbContext = scope.ServiceProvider.GetRequiredService<EventsDBContext>();
                bokedSeats = activityDbContext.ActivitySeats
                    .AsNoTracking()
                    .Where(activitySeat => seatIds.Contains(activitySeat.Id)).ToList();
            }

            // Assert - Payment - Order - Seats
            Assert.NotNull(completedPayment);
            Assert.True(completedPayment.Status == PaymentStatus.Failed);

            Assert.NotNull(paidOrder);
            Assert.True(paidOrder.Status == OrderStatus.Failed);

            Assert.True(completedPayment.Amount == paidOrder.Amount);

            Assert.True(Array.TrueForAll(soldSeats.ToArray(), s => s.State == SeatState.Available));
            #endregion
        }
    }
}
