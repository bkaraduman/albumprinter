using Albelli.Api.Application.Concrete;
using Albelli.Api.Application.Validation;
using Albelli.Common.Infrastructure.Exceptions;
using Albelli.Common.Models.RequestModels;
using Albelli.Infrastructure.Persistence.Repositories.Interface;
using AutoMapper;
using FluentAssertions;
using FluentValidation.TestHelper;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Albelli.Api.Test.System.Services
{
    public class TestOrderService
    {
        private readonly Mock<IOrderRepository> _orderRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly OrderValidation _orderValidation;

        public TestOrderService()
        {
            _orderRepository = new Mock<IOrderRepository>();
            _mapper = new Mock<IMapper>();

            _orderValidation = new OrderValidation();
        }

        [Fact]
        public async Task GetOrderAsync_IdNotFound_ShouldReturnNotFoundException()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            var orderService = new OrderService(_orderRepository.Object, _mapper.Object);

            // Act
            Func<Task> act = () => orderService.Get(id);

            // Assert
            await act.Should().ThrowAsync<NotFoundException>();
        }


        [Fact]
        public async Task CreateOrderAsync_InvalidOrderId_ShouldReturnException()
        {
            var orderService = new OrderService(_orderRepository.Object, _mapper.Object);

            // Act
            OrderRequestDto orderRequestDto = new();

            var result = _orderValidation.TestValidate(orderRequestDto);

            result.ShouldHaveValidationErrorFor("OrderId");            

            Func<Task> act = () => orderService.Insert(orderRequestDto);

            // Assert
            await act.Should().ThrowAsync<ValidationException>();
        }

        [Fact]
        public void CreateOrderAsync_InvalidProductType_ShouldReturnException()
        {
            OrderRequestDto orderRequestDto = new()
            {
                OrderId = Guid.NewGuid(),
                OrderDetails = new List<OrderDetailRequestDto>
                {
                    new OrderDetailRequestDto
                    {
                        ProductType=7,
                        Price=1,
                        Quantity=1
                    }
                }
            };

            var result = _orderValidation.TestValidate(orderRequestDto);

            result.ShouldHaveValidationErrorFor("OrderDetails[0].ProductType");
        }
    }
}
