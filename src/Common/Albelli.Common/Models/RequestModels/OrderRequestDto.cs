namespace Albelli.Common.Models.RequestModels
{
    public class OrderRequestDto
    {
        public OrderRequestDto()
        {
            OrderDetails = new List<OrderDetailRequestDto>();
        }
        public List<OrderDetailRequestDto> OrderDetails { get; set; }

        public Guid OrderId { get; set; }
    }
}
