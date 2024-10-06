using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ticketing.Shared.Data.Repository;

namespace Modules.Orders.Data
{
    public static class ServicesExtensions
    {
        public static void AddOrdersData(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrdersDBContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString(OrdersDBConstants.DBConnectionKey));
            });

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
