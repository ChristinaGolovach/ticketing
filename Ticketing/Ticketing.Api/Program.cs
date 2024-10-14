using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using Modules.Events.Data;
using Modules.Orders.Data;
using Modules.Orders.ModuleApi;
using Modules.Payments.Data;
using Modules.Payments.Api;
using Modules.Users.Data;
using Modules.Events.Api;
using Modules.Events.ModuleApi;
using Modules.Orders.Api;
using Ticketing.Api.Filters;
using Ticketing.Shared.Messaging;
using Ticketing.Shared.Data.Repository;


namespace Ticketing.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddEventsData(builder.Configuration);
            builder.Services.AddOrdersData(builder.Configuration);
            builder.Services.AddPaymentsData(builder.Configuration);
            builder.Services.AddUsersData(builder.Configuration);

            builder.Services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

            builder.Services.AddEventApi();
            builder.Services.AddOrderApi();
            builder.Services.AddPaymentApi();

            builder.Services.AddEventModuleApi();
            builder.Services.AddOrderModuleApi();

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

            app.MapControllers();


            app.Run();
        }
    }
}
