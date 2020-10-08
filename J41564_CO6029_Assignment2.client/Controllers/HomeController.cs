using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using J41564_CO6029_Assignment2.client.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace J41564_CO6029_Assignment2.client.Controllers
{
    public class HomeController : Controller
    {
        public List<Order> orderList = new List<Order>();
        public List<Customer> customerList = new List<Customer>();
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CustomersAsync()
        {
            customerList = await CustomersCallAsync();
            return View(new CustomersViewModel { CustomerList = customerList });
        }

        private static async Task<List<Customer>> CustomersCallAsync()
        {
            using (var client = new HttpClient())
            {
                var content = await client.GetStringAsync("https://api.co6029.1721102.win.studentwebserver.co.uk/api/customers");
                return JsonConvert.DeserializeObject<List<Customer>>(content);
            }
        
        }

        public async Task<IActionResult> OrdersAsync()
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
