using Albelli.Common.Models.RequestModels;
using Albelli.Common.Models.ResponseModels;

namespace Albelli.Api.Application.Abstract
{
    public interface IOrderService
    {
        public Task<OrderDto> Get(Guid id);
        public Task<Guid> Save(OrderRequestDto order);
    }
}
