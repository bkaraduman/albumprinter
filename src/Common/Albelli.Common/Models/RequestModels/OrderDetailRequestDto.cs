namespace Albelli.Common.Models.RequestModels
{
    public class OrderDetailRequestDto
    {
        public int ProductType { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
