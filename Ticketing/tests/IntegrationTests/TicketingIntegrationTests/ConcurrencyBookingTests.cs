using Modules.Orders.Core.Models;
using System.Net.Http.Json;
using TicketingIntegrationTests.Configuration;
using Xunit;

namespace TicketingIntegrationTests
{
    public class ConcurrencyBookingTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory _factory;

        public ConcurrencyBookingTests(CustomWebApplicationFactory factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task SubmitOrder_ShouldBe_OneSuccessfulOrder_WhenBookTheSamePlace()
        {
            // Arrange
            var orderId = new Guid("43AE8DDC-0528-4D89-B947-08B12B688B89");
            IList<Task<HttpResponseMessage>> orderSubmitRequests = new List<Task<HttpResponseMessage>>();

            for (int i = 0; i < 5; i++)
            {
                orderSubmitRequests.Add(_client.PutAsJsonAsync($"/api/orders/{orderId}/action", OrderAction.Submit));
            }

            // Act
            var orderSubmitResponses = await Task.WhenAll(orderSubmitRequests);
            var successfulOrderCount = orderSubmitResponses.Count(x => x.StatusCode == System.Net.HttpStatusCode.OK);

            // Assert
            Assert.True(successfulOrderCount == 1);
        }


        //[Fact]
        // TODO: ASK - On Fake DB Version is not work ?????????
        //public async Task SubmitOrder_ShouldBe_OneSuccessfulOrder_WhenBookTheSamePlace_FakeDB()
        //{
        //    // Arrange
        //    var userId = new Guid("c4b4f2ba-67f7-4193-8406-89f269081b6c");
        //    var seat = new AddSeatDto()
        //    {
        //        ActivityId = new Guid("8B5FA894-DFCF-4BB4-A605-5F99985C3805"),
        //        ActivitySeatId = new Guid("28eeaa98-3068-4a7a-8b6e-4457d81d5312"),
        //        Amount = 150
        //    };

        //    IList<Guid> orderIds = new List<Guid>();
        //    IList<Task<HttpResponseMessage>> orderAddItemRequests = new List<Task<HttpResponseMessage>>();
        //    IList<Task<HttpResponseMessage>> orderSubmitRequests = new List<Task<HttpResponseMessage>>();

        //    using (var scope = _factory.Services.CreateScope())
        //    {
        //        for (int i = 0; i < 10; i++)
        //        {
        //            var orderId = Guid.NewGuid();
        //            var orderDbContext = scope.ServiceProvider.GetRequiredService<OrdersDBContext>();
        //            orderDbContext.Orders.Add(new Modules.Orders.Data.Entities.Order
        //            {
        //                Id = orderId,
        //                UserId = userId,
        //                ActivityId = seat.ActivityId,
        //                Amount = 0
        //            });
        //            orderDbContext.SaveChanges();

        //            orderIds.Add(orderId);
        //            orderAddItemRequests.Add(_client.PostAsJsonAsync($"/api/orders/{orderId}", seat));
        //        }
        //    }
        //    await Task.WhenAll(orderAddItemRequests);

        //    foreach (var orderId in orderIds)
        //    {
        //        orderSubmitRequests.Add(_client.PutAsJsonAsync($"/api/orders/{orderId}/action", OrderAction.Submit));

        //    }

        //    // Act
        //    var orderSubmitResponses = await Task.WhenAll(orderSubmitRequests);
        //    var successfulOrderCount = orderSubmitResponses.Count(x => x.StatusCode == System.Net.HttpStatusCode.OK);

        //    // Assert
        //    Assert.True(successfulOrderCount == 1);
        //}
    }
}

