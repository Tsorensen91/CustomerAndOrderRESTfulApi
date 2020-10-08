using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using J41564_CO6029_Assignment2.client.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace J41564_CO6029_Assignment2.client.Controllers
{
    public class OrdersController : Controller
    {
        public List<Order> orderList = new List<Order>();
        public async Task<IActionResult> IndexAsync()
        {
            orderList = await OrdersCallAsync();
            return View(new OrdersViewModel { OrderList = orderList });
        }

        private static async Task<List<Order>> OrdersCallAsync()
        {
            using (var client = new HttpClient())
            {
                var content = await client.GetStringAsync("https://api.co6029.1721102.win.studentwebserver.co.uk/api/orders");
                return JsonConvert.DeserializeObject<List<Order>>(content);
            }
        }
    }
}