using Albelli.Api.Domain.Models;
using Albelli.Infrastructure.Persistence.Context;
using Albelli.Infrastructure.Persistence.Repositories.Interface;

namespace Albelli.Infrastructure.Persistence.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(AlbelliContext context) : base(context)
        {
        }
    }
}
