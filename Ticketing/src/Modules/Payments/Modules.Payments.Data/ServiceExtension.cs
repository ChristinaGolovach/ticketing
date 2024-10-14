using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ticketing.Shared.Data.Repository;

namespace Modules.Payments.Data
{
    public static class ServicesExtensions
    {
        public static void AddPaymentsData(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PaymentsDBContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString(PaymentsDBConstants.DBConnectionKey));
            });
        }
    }
}
