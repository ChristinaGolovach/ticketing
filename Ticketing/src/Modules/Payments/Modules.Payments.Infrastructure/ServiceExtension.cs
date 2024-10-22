using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.Payments.Infrastructure.Data;


namespace Modules.Payments.Infrastructure
{
    public static class ServicesExtensions
    {
        public static void AddPaymentsInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PaymentsDBContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString(PaymentsDBConstants.DBConnectionKey));
            });
        }
    }
}
