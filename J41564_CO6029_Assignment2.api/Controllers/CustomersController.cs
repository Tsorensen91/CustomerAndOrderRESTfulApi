using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using J41564_CO6029_Assignment2.api.Models;
using J41564_CO6029_Assignment2.api.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace J41564_CO6029_Assignment2.api.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            IEnumerable<CustomerModel> customerModels = _customerService.GetAllCustomers();
            return Ok(customerModels);
        }


    }
}
