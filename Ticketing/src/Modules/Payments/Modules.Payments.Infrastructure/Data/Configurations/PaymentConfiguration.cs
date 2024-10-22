using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Payments.Data.Entities;
using Ticketing.Shared.Infrastructure.Data;

using static Modules.Payments.Infrastructure.Data.PaymentsDBConstants;

namespace Modules.Payments.Infrastructure.Data.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable(PaymentTable.TableName);

            builder.BaseEntityConfigure();

            builder.Property(order => order.Status)
                .IsRequired();

            builder.Property(order => order.Amount)
                .IsRequired();

            builder.Property(order => order.OrderId)
                .IsRequired();
        }
    }
}
