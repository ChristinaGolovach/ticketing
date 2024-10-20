using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.Orders.Infrastructure.Data;

namespace Modules.Orders.Infrastructure
{
    public static class ServicesExtensions
    {
        public static void AddOrdersInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrdersDBContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString(OrdersDBConstants.DBConnectionKey));
            });
        }
    }
}
