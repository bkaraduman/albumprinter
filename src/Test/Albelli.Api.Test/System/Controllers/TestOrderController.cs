using Albelli.Api.Application.Abstract;
using Albelli.Api.Test.MockData;
using Albelli.Api.WebApi.Controllers;
using Albelli.Common;
using Albelli.Common.Models;
using Albelli.Common.Models.RequestModels;
using Albelli.Common.Models.ResponseModels;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Albelli.Api.Test.System.Controllers
{
    public class TestOrderController
    {
        private readonly Mock<IOrderService> _orderService;
        private readonly OrderController _orderController;

        private readonly List<OrderDto> orders;

        public TestOrderController()
        {
            _orderService = new Mock<IOrderService>();
            _orderController = new OrderController(_orderService.Object);

            orders = OrderMockData.GetOrders();
        }


        [Theory]
        [InlineData("1ca0c925-c4d3-4fdf-9f51-f5d71f4d33e2")]
        public async Task GetOrderAsync_ActionExecutes_ShouldReturn200StatusWithOrderId(string id)
        {
            // Arrange
            Guid orderId = new(id);

            OrderDto order = orders.FirstOrDefault(o => o.Id == orderId);

            _orderService.Setup(x => x.Get(orderId)).ReturnsAsync(order);

            // Act
            var result = (OkObjectResult)await _orderController.Get(orderId);

            // Assert
            result.StatusCode.Should().Be(200);
            result.Value.Should().BeOfType<ApiResponseDto>();

            var apiResponse = (ApiResponseDto)result.Value;

            _ = apiResponse.Result.Should().BeOfType<OrderDto>();

            var response = (OrderDto)apiResponse.Result;

            _ = response.Id.Should().Be(orderId);
        }


        [Fact]
        public async Task GetOrderAsync_IdInvalid_ReturnValidationException()
        {
            // Arrange
            Guid orderId = Guid.NewGuid();

            OrderDto order = null;

            _orderService.Setup(x => x.Get(orderId)).ReturnsAsync(order);

            // Act
            var result = (OkObjectResult)await _orderController.Get(orderId);

            // Assert
            result.Value.Should().BeOfType<ApiResponseDto>();

            var apiResponse = (ApiResponseDto)result.Value;

            _ = apiResponse.Result.Should().Be(null);
        }


        [Fact]
        public async Task Create_ActionExecutes_ShouldReturn200()
        {
            // Arrange
            Guid orderId = Guid.NewGuid();
            OrderRequestDto orderRequest = null;

            _orderService.Setup(repo => repo.Insert(It.IsAny<OrderRequestDto>())).Callback<OrderRequestDto>(x => orderRequest = x);

            // Act
            var result = (OkObjectResult)await _orderController.Insert(new OrderRequestDto
            {
                OrderId = orderId,
                OrderDetails = new List<OrderDetailRequestDto>
                {
                        new OrderDetailRequestDto{
                        Price=10,
                        Quantity=1,
                        ProductType=(int)ProductType.Mug
                    }
                }
            });

            // Assert
            _orderService.Verify(repo => repo.Insert(It.IsAny<OrderRequestDto>()), Times.Once);

            orderRequest.OrderId.Should().Be(orderId);
        }
    }
}
