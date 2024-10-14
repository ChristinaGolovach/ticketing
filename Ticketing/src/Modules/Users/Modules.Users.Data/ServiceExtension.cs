using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ticketing.Shared.Data.Repository;

namespace Modules.Users.Data
{
    public static class ServicesExtensions
    {
        public static void AddUsersData(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UsersDBContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString(UsersDBConstants.DBConnectionKey));
            });
        }
    }
}
