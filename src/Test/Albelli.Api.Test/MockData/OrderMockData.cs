using Albelli.Common;
using Albelli.Common.Models;
using Albelli.Common.Models.RequestModels;
using Albelli.Common.Models.ResponseModels;
using System;
using System.Collections.Generic;

namespace Albelli.Api.Test.MockData
{
    public static class OrderMockData
    {
        public static List<OrderDto> GetOrders()
        {
            return new List<OrderDto>
            {
                new OrderDto
                {
                    Id = new Guid("1ca0c925-c4d3-4fdf-9f51-f5d71f4d33e2"),
                    OrderDate = DateTime.Now.ToLongDateString(),
                    OrderDetails = new List<OrderDetailDto>{
                        new OrderDetailDto
                        {
                            ProductType=ProductType.Mug,
                            Quantity=5,
                            Price=10
                        },
                        new OrderDetailDto
                        {
                            ProductType=ProductType.Canvas,
                            Quantity=1,
                            Price=10,
                        }
                    }
                },
            };
        }
    }
}
