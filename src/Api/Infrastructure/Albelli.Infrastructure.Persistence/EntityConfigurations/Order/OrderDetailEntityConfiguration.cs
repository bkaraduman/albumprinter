using Albelli.Api.Domain.Models;
using Albelli.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Albelli.Infrastructure.Persistence.EntityConfigurations.Product
{
    public class OrderDetailEntityConfiguration : BaseEntityConfiguration<Api.Domain.Models.OrderDetail>
    {
        public override void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            base.Configure(builder);

            builder.ToTable("orderdetails", AlbelliContext.DEFAULT_SCHEMA);

            builder.HasOne(i => i.Order)
                .WithMany(i => i.OrderDetails)
                .HasForeignKey(i => i.OrderId);
        }
    }
}
