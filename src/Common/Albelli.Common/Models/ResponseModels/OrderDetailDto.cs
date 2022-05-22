namespace Albelli.Common.Models.ResponseModels
{
    public class OrderDetailDto
    {
        public ProductType ProductType { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; } 
    }
}
