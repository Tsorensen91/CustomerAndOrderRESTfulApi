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
    public class CustomersController : Controller
    {
        public List<Customer> customerList = new List<Customer>();
        public async Task<IActionResult> IndexAsync()
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
    }
}