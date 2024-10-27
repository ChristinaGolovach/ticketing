using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

using Modules.Events.Api;
using Modules.Events.Infrastructure;
using Modules.Events.ModuleApi;
using Modules.Orders.Api;
using Modules.Orders.Infrastructure;
using Modules.Orders.ModuleApi;
using Modules.Payments.Api;
using Modules.Payments.Infrastructure;
using Modules.Payments.ModuleApi;
using Modules.Users.Data;
using Ticketing.Api.Filters;
using Ticketing.Shared.Infrastructure;
using Ticketing.Shared.Infrastructure.Data;
using Ticketing.Shared.Messaging;

namespace Ticketing.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddEventsInfrastructure(builder.Configuration);
            builder.Services.AddOrdersInfrastructure(builder.Configuration);
            builder.Services.AddPaymentsInfrastructure(builder.Configuration);
            builder.Services.AddSharedInfrastructure(builder.Configuration);
            builder.Services.AddUsersData(builder.Configuration);

            builder.Services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

            builder.Services.AddEventApi();
            builder.Services.AddOrderApi();
            builder.Services.AddPaymentApi();

            builder.Services.AddEventModuleApi();
            builder.Services.AddOrderModuleApi();
            builder.Services.AddPaymentModuleApi();

            builder.Services.AddSharedRequests();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ticketing API", Version = "v1" });
            });

            builder.Services.AddRouting(options => options.LowercaseUrls = true);
            builder.Services.AddControllers(options =>
            {
                options.Filters.Add<ExceptionFilter>();
            }).AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            //app.UseHttpsRedirection();
            //app.UseRouting(); //
            //app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ticketing API");
                c.RoutePrefix = string.Empty;
            });

            app.UseResponseCaching();

            app.MapControllers();

            app.Run();
        }
    }
}
