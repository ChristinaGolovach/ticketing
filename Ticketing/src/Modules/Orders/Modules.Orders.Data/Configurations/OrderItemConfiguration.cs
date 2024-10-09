using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Orders.Data.Entities;
using Ticketing.Shared.Data;

using static Modules.Orders.Data.OrdersDBConstants;

namespace Modules.Orders.Data.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable(OrderItemTable.TableName);

            builder.BaseEntityConfigure();

            builder.Property(orderItem => orderItem.Amount)
                .IsRequired();

            builder.Property(orderItem => orderItem.ActivitySeatId)
                .IsRequired();

            builder.HasOne(orderItem => orderItem.Order)
                .WithMany(order => order.OrderItems)
                .HasForeignKey(orderItem => orderItem.OrderId);
        }
    }
}
