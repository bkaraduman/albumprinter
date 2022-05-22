namespace Albelli.Api.Domain.Models
{
    public class Order : BaseEntity
    {
        public int RequiredBinWidth { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
