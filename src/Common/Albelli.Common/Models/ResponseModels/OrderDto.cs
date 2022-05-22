namespace Albelli.Common.Models.ResponseModels
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public decimal TotalPrice { get; set; } 
        public int RequiredBinWidth { get; set; }
        public string OrderDate { get; set; }
        public List<OrderDetailDto> OrderDetails { get; set; }
    }
}
