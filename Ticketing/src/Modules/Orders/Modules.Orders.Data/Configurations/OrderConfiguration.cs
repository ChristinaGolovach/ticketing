using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Orders.Data.Entities;
using Ticketing.Shared.Data;

using static Modules.Orders.Data.OrdersDBConstants;

namespace Modules.Orders.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable(OrderTable.TableName);

            builder.BaseEntityConfigure();

            builder.Property(order => order.Status)
                .IsRequired();

            builder.Property(order => order.Amount)
                .IsRequired();

            builder.Property(order => order.UserId)
                .IsRequired();

            builder.Property(order => order.ActivityId)
                .IsRequired();

            builder.HasMany(order => order.OrderItems)
                .WithOne(orderItems => orderItems.Order)
                .HasForeignKey(orderItems => orderItems.OrderId);
        }
    }
}
