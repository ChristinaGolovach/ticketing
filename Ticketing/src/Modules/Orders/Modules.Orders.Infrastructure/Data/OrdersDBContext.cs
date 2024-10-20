using Microsoft.EntityFrameworkCore;
using Modules.Orders.Data.Entities;

namespace Modules.Orders.Infrastructure.Data
{
    public class OrdersDBContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public OrdersDBContext(DbContextOptions<OrdersDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(OrdersDBConstants.SchemaName);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            DataSeed(modelBuilder);
        }

        private void DataSeed(ModelBuilder modelBuilder)
        {
            SeedOrder(modelBuilder);
            SeedOrderItems(modelBuilder);
        }

        private void SeedOrder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData(
                new Order { Id = new Guid("43ae8ddc-0528-4d89-b947-08b12b688b89"), Status = OrderStatus.InProgress, Amount = 1250, UserId = new Guid("c4b4f2ba-67f7-4193-8406-89f269081b6c"), ActivityId = new Guid("8B5FA894-DFCF-4BB4-A605-5F99985C3805") },
                new Order { Id = new Guid("283d9fcf-6b89-4747-a70f-91b3f3c9954f"), Status = OrderStatus.InProgress, Amount = 50.5, UserId = new Guid("3bb7f4ce-d6a7-48e4-bb71-e8e2268bd3e9"), ActivityId = new Guid("7933E0D3-4905-4D2C-B9A1-C20EAD197883") });
        }

        private void SeedOrderItems(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem { Id = new Guid("8c9922e2-98fa-4bfd-82bc-5930db899848"), Amount = 250, OrderId = new Guid("43ae8ddc-0528-4d89-b947-08b12b688b89"), ActivitySeatId = new Guid("28eeaa98-3068-4a7a-8b6e-4457d81d5312") },
                new OrderItem { Id = new Guid("b588359f-97c6-46fa-9c3d-e4f5098c0218"), Amount = 250, OrderId = new Guid("43ae8ddc-0528-4d89-b947-08b12b688b89"), ActivitySeatId = new Guid("d4016119-36b7-459a-a79f-534f5d69efb3") },
                new OrderItem { Id = new Guid("83e6feed-73e5-4db2-a192-97310ab2b8d5"), Amount = 250, OrderId = new Guid("43ae8ddc-0528-4d89-b947-08b12b688b89"), ActivitySeatId = new Guid("433cf7f1-ca84-46fe-9eed-d33124b84acd") },
                new OrderItem { Id = new Guid("314530bd-eddb-4753-aeda-6ff8d9aa4dd1"), Amount = 500, OrderId = new Guid("43ae8ddc-0528-4d89-b947-08b12b688b89"), ActivitySeatId = new Guid("194b2efc-02c8-45ab-a375-408e65f30c4a") },
                new OrderItem { Id = new Guid("542357cb-6caf-4316-9b54-e605fcc81bf5"), Amount = 50.5, OrderId = new Guid("283d9fcf-6b89-4747-a70f-91b3f3c9954f"), ActivitySeatId = new Guid("087b509d-1ada-492e-a9c7-ed3e917bb2fb") });
        }
    }
}
