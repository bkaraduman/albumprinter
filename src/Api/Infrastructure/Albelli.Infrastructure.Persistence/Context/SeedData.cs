using Albelli.Api.Domain.Models;
using Albelli.Common.Infrastructure;
using Albelli.Common.Models;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Albelli.Infrastructure.Persistence.Context
{
    public class SeedData
    {
        public async Task SeedAsync(IConfiguration configuration)
        {
            var dbContextBuilder = new DbContextOptionsBuilder();

            dbContextBuilder.UseSqlServer(configuration["AlbelliDbConnectionString"]);

            var context = new AlbelliContext(dbContextBuilder.Options);

            if (context.Orders.Any())
            {
                await Task.CompletedTask;

                return;
            }

            var guids = Enumerable.Range(0, 5).Select(x => Guid.NewGuid()).ToList();

            int counter = 0;

            var orders = new Faker<Order>("tr")
            .RuleFor(x => x.Id, i => guids[counter++])
            .RuleFor(x => x.CreatedDate, i => i.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now))
            .RuleFor(x => x.RequiredBinWidth, i => i.Random.Int(10, 100))
            .Generate(5);

            await context.Orders.AddRangeAsync(orders);

            var orderDetails = new Faker<OrderDetail>("tr")
                .RuleFor(x => x.Id, i => Guid.NewGuid())
                .RuleFor(x => x.CreatedDate, i => i.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now))
                .RuleFor(x => x.OrderId, i => i.PickRandom(orders.Select(x => x.Id)))
                .RuleFor(x => x.Quantity, i => i.Random.Int(10, 100))
                .RuleFor(x => x.Price, i => i.Random.Decimal(10, 100))
                .RuleFor(x => x.ProductType, i => (ProductType)i.PickRandom(1, 2, 3, 4, 5))
                .Generate(10);

            await context.OrderDetails.AddRangeAsync(orderDetails);

            await context.SaveChangesAsync();
        }
    }
}
