using Albelli.Common.Models.RequestModels;
using FluentValidation;

namespace Albelli.Api.Application.Validation
{
    public class OrderValidation : ValidationBase<OrderRequestDto>
    {
        public OrderValidation()
        {
            RuleFor(x => x.OrderId).NotEmpty().WithMessage("Order id must be specified!");

            RuleFor(x => x.OrderDetails).Must(x => x.Count > 0).WithMessage("Order details must have at least one item!");

            RuleForEach(x => x.OrderDetails).ChildRules(detail =>
            {
                detail.RuleFor(x => x.ProductType).InclusiveBetween(1, 5).WithMessage("Product type must be between 1 and 5!");
            });

        }
    }
}
