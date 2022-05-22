using Albelli.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Albelli.Infrastructure.Persistence.EntityConfigurations.Order
{
    public class OrderEntityConfiguration : BaseEntityConfiguration<Api.Domain.Models.Order>
    {
        public override void Configure(EntityTypeBuilder<Api.Domain.Models.Order> builder)
        {
            base.Configure(builder);

            builder.ToTable("order", AlbelliContext.DEFAULT_SCHEMA);
        }
    }
}
