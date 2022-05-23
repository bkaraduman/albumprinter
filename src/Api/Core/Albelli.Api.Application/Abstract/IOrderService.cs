using Albelli.Common.Models.RequestModels;
using Albelli.Common.Models.ResponseModels;

namespace Albelli.Api.Application.Abstract
{
    public interface IOrderService
    {
        Task<OrderDto> Get(Guid id);
        Task<Guid> Insert(OrderRequestDto order);
    }
}
