using Albelli.Common.Models;

namespace Albelli.Api.Domain.Models
{
    public class OrderDetail : BaseEntity
    {
        public ProductType ProductType { get; set; }
        public int Quantity { get; set; }
        public Guid OrderId { get; set; }
        public decimal Price { get; set; }
        public virtual Order Order { get; set; }
    }
}
