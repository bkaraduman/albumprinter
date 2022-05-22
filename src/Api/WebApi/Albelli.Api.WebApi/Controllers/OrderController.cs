using Albelli.Api.Application.Abstract;
using Albelli.Api.WebApi.Controllers.Base;
using Albelli.Common.Models;
using Albelli.Common.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Albelli.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(new ApiResponseDto
            {
                Result = await _orderService.Get(id)
            });
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Insert([FromBody] OrderRequestDto model)
        {
            var result = await _orderService.Save(model);

            return Ok(new ApiResponseDto
            {
                Result = result
            });
        }
    }
}
