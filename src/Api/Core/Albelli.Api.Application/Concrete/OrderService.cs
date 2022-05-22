using Albelli.Api.Application.Abstract;
using Albelli.Api.Application.Validation;
using Albelli.Api.Domain.Models;
using Albelli.Common.Helper;
using Albelli.Common.Infrastructure.Exceptions;
using Albelli.Common.Models;
using Albelli.Common.Models.RequestModels;
using Albelli.Common.Models.ResponseModels;
using Albelli.Infrastructure.Persistence.Repositories.Interface;
using AutoMapper;

namespace Albelli.Api.Application.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly OrderValidation _validator;
        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;

            _validator = new OrderValidation();
        }
        public async Task<OrderDto> Get(Guid id)
        {
            var order = await _orderRepository.GetSingleAsync(x => x.Id == id, false, x => x.OrderDetails);

            if (order == null)
                throw new NotFoundException("Order not found with this id");

            var result = _mapper.Map<OrderDto>(order);

            result.OrderDetails = _mapper.Map<List<OrderDetailDto>>(order.OrderDetails);

            return result;
        }

        public async Task<Guid> Save(OrderRequestDto order)
        {
            this._validator.Validate(order);

            var result = _mapper.Map<Order>(order);

            result.RequiredBinWidth = OrderHelper.CalculateRequiredBinWidth(GetProductTypesFromRequest(order.OrderDetails));
            result.Id = order.OrderId;

            result.OrderDetails = _mapper.Map<List<OrderDetail>>(order.OrderDetails);

            await _orderRepository.AddAsync(result);

            return result.Id;
        }

        private static List<ProductType> GetProductTypesFromRequest(List<OrderDetailRequestDto> orderDetailRequests)
        {
            List<ProductType> productTypeList = new();

            foreach (var item in orderDetailRequests)
            {
                for (int i = 1; i <= item.Quantity; i++)
                {
                    productTypeList.Add((ProductType)item.ProductType);
                }
            }

            return productTypeList;
        }
    }
}
