using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using J41564_CO6029_Assignment2.api.Classes;
using J41564_CO6029_Assignment2.api.Models;
using J41564_CO6029_Assignment2.api.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace J41564_CO6029_Assignment2.api.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            IEnumerable<OrderModel> orderModels = _orderService.GetAllOrders();
            return Ok(orderModels);
        }


    }
}
