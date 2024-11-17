using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Modules.Events.Infrastructure.Data;
using Modules.Orders.Infrastructure.Data;
using Modules.Payments.Infrastructure.Data;
using Ticketing.Api;
using TicketingIntegrationTests.InMemoryDB;

namespace TicketingIntegrationTests.Configuration
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                //services.ReplaceDbContext<EventsDBContext>(
                //options =>
                //{
                //    options.UseInMemoryDatabase("InMemoryDB");
                //});
                //services.ReplaceDbContext<OrdersDBContext>(
                //options =>
                //{
                //    options.UseInMemoryDatabase("InMemoryDB");
                //});
                //services.ReplaceDbContext<PaymentsDBContext>(
                //options =>
                //{
                //    options.UseInMemoryDatabase("InMemoryDB");
                //});

                var sp = services.BuildServiceProvider(validateScopes: true);
                //new DBSeeder().SeedDatabase(sp);
            });
        }
    }
}
