using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wheelzy.Models.Dto;
using Wheelzy.Services.Contracts;

namespace Wheelzy.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _orderService.GetOrdersHistory();

            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<OrderDto> req)
        {
            var response = await _orderService.SaveOrders(req);

            return Ok(response);
        }
    }
}
